using System;
using System.ComponentModel.DataAnnotations;

namespace ChallengeAlternativo.Models
{
    public class GeographicIcon
    {
        [Key]
        public int? GeoIconId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public double Height { get; set; }
        public string History { get; set; }

        public City City { get; set; } = null!;
    }
}
