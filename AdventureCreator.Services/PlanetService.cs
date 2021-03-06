﻿using AdventureCreator.Data;
using AdventurerCreator.Models.Adventurer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureCreator.Services
{
    public class PlanetService
    {
        private readonly Guid _userId;
        public PlanetService(Guid userId)
        {
            _userId = userId;
        }

        public bool PlanetCreate(PlanetCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newPlanet = new Planet()
                {
                    Name = model.Name,
                    PrimaryColor = model.PrimaryColor.ToLower(),
                    SecondaryColor = model.SecondaryColor.ToLower(),
                    UserId = _userId
                };
                ctx.Planets.Add(newPlanet);
                return ctx.SaveChanges() == 1;
            }
        }

        public List<PlanetListItem> PlanetList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var planetEntity = ctx.Planets;
                var planetList = new List<PlanetListItem>();
                foreach (var item in planetEntity)
                {
                    var planetListItem = new PlanetListItem()
                    {
                        PlanetId = item.PlanetId,
                        Name = item.Name,
                        BadGuys = item.BadGuys,
                        PrimaryColor = item.PrimaryColor,
                        SecondaryColor = item.SecondaryColor
                    };
                    planetList.Add(planetListItem);
                }

                return planetList;
            }
        }
        public List<BadGuyListItem> PlanetBadGuyList(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var badguyEntity = ctx.BadGuys;
                var badGuyList = new List<BadGuyListItem>();
                foreach (var item in badguyEntity)
                {
                    if (item.PlanetId == id)
                    {
                        var badGuyListItem = new BadGuyListItem()
                        {
                            BadGuyId = item.BadGuyId,
                            Name = item.Name,
                            PlanetName = item.Planet.Name,
                            Class = item.Class,
                            IsBoss = item.IsBoss,
                            Level = item.Level
                        };
                        badGuyList.Add(badGuyListItem);
                    }
                }

                return badGuyList;
            }
        }


        public PlanetDetails GetPlanetById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var planetEntity = ctx.Planets
                    .Single(e => e.PlanetId == id && e.UserId == _userId);
                return new PlanetDetails
                {
                    PlanetId = planetEntity.PlanetId,
                    Name = planetEntity.Name,
                    PrimaryColor = planetEntity.PrimaryColor,
                    SecondaryColor = planetEntity.SecondaryColor,
                    BadGuys = planetEntity.BadGuys
                };
            }
        }

        public bool UpdatePlanet(PlanetEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var planetEntity = ctx.Planets
                        .Single(e => e.PlanetId == model.PlanetId && _userId == e.UserId);
                planetEntity.Name = model.Name;
                planetEntity.PrimaryColor = model.PrimaryColor;
                planetEntity.SecondaryColor = model.SecondaryColor;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlanet(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var planetEntity = ctx.Planets
                        .Single(e => e.PlanetId == id && _userId == e.UserId);
                ctx.Planets.Remove(planetEntity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

