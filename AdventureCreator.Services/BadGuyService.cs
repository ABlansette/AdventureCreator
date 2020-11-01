using AdventureCreator.Data;
using AdventurerCreator.Models.Adventurer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureCreator.Services
{
    public class BadGuyService
    {
        private readonly Guid _userId;
        public BadGuyService(Guid userId)
        {
            _userId = userId;
        }

        public bool BadGuyCreate(BadGuyCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newBadGuy = new BadGuy()
                {
                    Name = model.Name,
                    Level = model.Level,
                    Class = model.Class,
                    PlanetId = model.PlanetId,
                    UserId = _userId
                };
                ctx.BadGuys.Add(newBadGuy);
                return ctx.SaveChanges() == 1;
            }

        }
        public List<BadGuyListItem> BadGuyList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var badGuyEntity = ctx.BadGuys;
                var badGuyList = new List<BadGuyListItem>();
                foreach (var item in badGuyEntity)
                {
                    var badGuyListItem = new BadGuyListItem()
                    {
                        BadGuyId = item.BadGuyId,
                        Name = item.Name,
                        PlanetName = item.PlanetName,
                        Class = item.Class,
                        Level = item.Level,
                        IsBoss = item.IsBoss
                    };
                    badGuyList.Add(badGuyListItem);
                }
                return badGuyList;
            }
        }

        public BadGuyDetails GetBadGuyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var badGuyEntity = ctx.BadGuys
                    .Single(e => e.BadGuyId == id && e.UserId == _userId);
                return new BadGuyDetails
                {
                    BadGuyId = badGuyEntity.BadGuyId,
                    Name = badGuyEntity.Name,
                    Damage = badGuyEntity.Damage,
                    Health = badGuyEntity.Health,
                    Level = badGuyEntity.Level,
                    IsBoss = badGuyEntity.IsBoss,
                    PlanetName = badGuyEntity.Planet.Name,
                    XpDropped = badGuyEntity.XpDropped,
                    UserId = _userId,
                    Class = badGuyEntity.Class
                };
            }
        }

        public bool UpdateBadGuy(BadGuyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var badGuyEntity = ctx.BadGuys
                        .Single(e => e.BadGuyId == model.BadGuyId && _userId == e.UserId);
                badGuyEntity.Name = model.Name;
                badGuyEntity.Class = model.Class;
                badGuyEntity.IsBoss = model.IsBoss;
                badGuyEntity.Level = model.Level;
                badGuyEntity.PlanetId = model.PlanetId;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBadGuy(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var badGuyEntity = ctx.BadGuys
                        .Single(e => e.BadGuyId == id && _userId == e.UserId);
                ctx.BadGuys.Remove(badGuyEntity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

