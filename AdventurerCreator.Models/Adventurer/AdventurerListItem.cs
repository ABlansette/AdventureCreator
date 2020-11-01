using AdventureCreator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventurerCreator.Models.Adventurer
{
    public class AdventurerListItem
    {
        public int AdventurerId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public Species Class { get; set; }
        public string PlanetName { get; set; }
    }
}
