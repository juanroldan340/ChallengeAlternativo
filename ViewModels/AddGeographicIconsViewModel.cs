using ChallengeAlternativo.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ChallengeAlternativo.ViewModels
{
    public class AddGeographicIconsViewModel : GenericViewModel
    {
        [Display(Name = "Fecha de Creación")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Display(Name = "Altura")]
        public double Height { get; set; }

        [Display(Name = "Historia")]
        public string History { get; set; }

        [Display(Name = "Ciudades")]
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
