using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureCreator.Data
{
    public class BadGuy
    {
        [Key]
        public int BadGuyId { get; set; }

        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        public double Health => Level * 200;

        [Required]
        public double Damage => Level * 19;

        [Required]
        public int XpDropped => Level * 10;

        [Required]
        [ForeignKey(nameof(Planet))]
        public int PlanetId { get; set; }

        public virtual Planet Planet { get; set; }
        public BadGuySpecies Class { get; set; }

        [Required]
        public bool IsBoss { get; set; }

        public string PlanetName => Planet.Name;
        }
    public enum BadGuySpecies { Goblin, Ghost, Alein, SpaceMonkey, Skeleton, TreeMonster }
}
