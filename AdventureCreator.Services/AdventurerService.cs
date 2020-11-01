using AdventureCreator.Data;
using AdventurerCreator.Models.Adventurer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureCreator.Services
{
    public class AdventurerService
    {
        private readonly Guid _userId;
        public AdventurerService(Guid userId)
        {
            _userId = userId;
        }

        public bool AdventurerCreate(AdventurerCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newAdventurer = new Adventurer()
                {
                    Name = model.Name,
                    Class = model.Class,
                    Level = 1,
                    PlanetId = 1,
                    Weapon = model.WeaponChoice(),
                    Xp = 0,
                    OwnerId = _userId
                };
                ctx.Adventurers.Add(newAdventurer);
                return ctx.SaveChanges() == 1;
            }

        }
        public List<AdventurerListItem> AdventurerList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var adventurerEntity = ctx.Adventurers;
                var adventurerList = new List<AdventurerListItem>();
                foreach (var item in adventurerEntity)
                {
                    var adventurerListItem = new AdventurerListItem()
                    {
                        AdventurerId = item.AdventurerId,
                        Name = item.Name,
                        Class = item.Class,
                        Level = item.Level,
                        PlanetName = item.Planet.Name
                    };
                    adventurerList.Add(adventurerListItem);
                }
                return adventurerList;
            }
        }

        public AdventurerDetails GetAdventurerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var adventurerEntity = ctx.Adventurers
                    .Single(e => e.AdventurerId == id && e.OwnerId == _userId);
                return new AdventurerDetails
                {
                    AdventurerId = adventurerEntity.AdventurerId,
                    Name = adventurerEntity.Name,
                    Damage = adventurerEntity.Damage,
                    Health = adventurerEntity.Health,
                    Level = adventurerEntity.Level,
                    PlanetName = adventurerEntity.Planet.Name,
                    Class = adventurerEntity.Class,
                    Weapon = adventurerEntity.WeaponChoice()
                };
            }
        }

        public bool UpdateAdventurer(AdventurerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var adventurerEntity = ctx.Adventurers
                        .Single(e => e.AdventurerId == model.AdventurerId && _userId == e.OwnerId);
                adventurerEntity.Name = model.Name;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAdventurer(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var adventurerEntity = ctx.Adventurers
                        .Single(e => e.AdventurerId == id && _userId == e.OwnerId);
                ctx.Adventurers.Remove(adventurerEntity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
