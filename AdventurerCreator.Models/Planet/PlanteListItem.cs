using AdventureCreator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventurerCreator.Models.Adventurer
{
    public class PlanetListItem
    {
        public int PlanetId { get; set; }
        public string Name { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public virtual BadGuy BadGuys { get; set; }
    }
}
