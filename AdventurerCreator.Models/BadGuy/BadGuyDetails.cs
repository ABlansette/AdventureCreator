using AdventureCreator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventurerCreator.Models.Adventurer
{
    public class BadGuyDetails
    {
        public int BadGuyId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public double Health { get; set; }
        public double Damage { get; set; }
        public int XpDropped { get; set; }
        public bool IsBoss { get; set; }
        public string PlanetName { get; set; }
        public BadGuySpecies Class { get; set; }
        public virtual Planet Planet { get; set; }
    }
}
