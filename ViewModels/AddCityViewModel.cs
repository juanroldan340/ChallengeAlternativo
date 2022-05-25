using ChallengeAlternativo.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChallengeAlternativo.ViewModels
{
    public class AddCityViewModel : GenericViewModel
    {
        [Required(ErrorMessage = "La cantidad de habitantes es obligatoria")]
        [Display(Name = "Habitantes")]
        public int Population { get; set; }

        [Display(Name = "Superficie Total (m2)")]
        public double Area { get; set; }

        [Display(Name = "Continente")]
        public int? ContinentId { get; set; }

        [Display(Name = "Icono Geográfico")]
        public ICollection<GeographicIcon> GeographicIcon { get; set; } = null!;

        public City ToCityModel() 
        {
            return new City()
            {
                CityId = null,
                Population = Population,
                Area = Area,
                ContinentId = ContinentId,
                GeographicIcon = GeographicIcon
            };
        }
    }
}
