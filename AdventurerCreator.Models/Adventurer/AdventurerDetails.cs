using AdventureCreator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventurerCreator.Models.Adventurer
{
    public class AdventurerDetails
    {
        public int AdventurerId { get; set; }
        public string Name { get; set; }
        public Species Class { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }
        public string Weapon { get; set; }
        public string PlanetName { get; set; }
        public virtual Planet Planet { get; set; }
    }
}
