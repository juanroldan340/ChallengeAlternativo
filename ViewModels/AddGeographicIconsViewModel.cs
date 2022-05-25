using ChallengeAlternativo.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ChallengeAlternativo.ViewModels
{
    public class AddGeographicIconsViewModel
    {
        public int GeoIconId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public double Height { get; set; }
        public string History { get; set; }

        public City City { get; set; } = null!;

        public GeographicIcon ToGeographicIconModel() 
        {
            return new GeographicIcon() 
            { 
                GeoIconId = null,
                Image = Image,
                Name = Name,
                CreationDate = CreationDate,
                Height = Height,
                History = History,
                City = City
            };
        }
    }
}
