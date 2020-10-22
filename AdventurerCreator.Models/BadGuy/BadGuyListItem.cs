using AdventureCreator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventurerCreator.Models.Adventurer
{
    public class BadGuyListItem
    {
        public int BadGuyId { get; set; }
        public string Name { get; set; }
        public BadGuySpecies Class { get; set; }
        public int Level { get; set; }

        //[Display("Boss")]
        public bool IsBoss { get; set; }
        public virtual Planet Planet { get; set; }
    }
}
