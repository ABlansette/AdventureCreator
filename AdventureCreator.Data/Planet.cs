using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureCreator.Data
{
    public class Planet
    {
        [Key]
        public int PlanetId { get; set; }

        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public ICollection<BadGuy> BadGuys { get; set; }

        /*public int NumOfBadGuys
        {
            get
            {
                return HowManyBaddies();
            }
        }*/


        /*public int HowManyBaddies()
        {
            var ctx = new ApplicationDbContext();
            List<BadGuy> badGuys = new List<BadGuy>(ctx.BadGuys);
            int count = 0;
            foreach (var badguy in badGuys)
            {
                if (badguy.PlanetId == this.PlanetId)
                {
                    count++;
                }
            }
            return count;
        }*/
    }

}
