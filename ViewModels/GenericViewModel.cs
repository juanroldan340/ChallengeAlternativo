using System.ComponentModel.DataAnnotations;

namespace ChallengeAlternativo.ViewModels
{
    public class GenericViewModel
    {
        [Required(ErrorMessage = "La imagen es obligatoria.")]
        [Display(Name = "Imagen")]
        public string Image { get; set; }

        [Required(ErrorMessage = "La denominación es obligatoria.")]
        [Display(Name = "Denominación")]
        public string Name { get; set; }
    }
}
