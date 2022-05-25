using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChallengeAlternativo.Models
{
    public class Continent
    {
        [Key]
        public int? ContinentId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; } = null!;
    }
}
