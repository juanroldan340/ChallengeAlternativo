using System.ComponentModel.DataAnnotations;

namespace ChallengeAlternativo.ViewModels
{
    public class GetCityViewModel : GenericViewModel
    {
        [Display(Name = "Cantidad de Habitantes")]
        public double Population { get; set; }
    }
}
