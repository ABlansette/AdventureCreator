using AdventureCreator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventurerCreator.Models.Adventurer
{
    public class BadGuyCreate
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public BadGuySpecies Class { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        public int  PlanetId { get; set; }

        [Required]
        public bool IsBoss { get; set; }
    }
}
