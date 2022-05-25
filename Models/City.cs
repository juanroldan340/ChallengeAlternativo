using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChallengeAlternativo.Models
{
    public class City
    {
        [Key]
        public int? CityId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public double Area { get; set; }
        public int? ContinentId { get; set; }

        public ICollection<GeographicIcon> GeographicIcon { get; set; } = null!;
    }
}
