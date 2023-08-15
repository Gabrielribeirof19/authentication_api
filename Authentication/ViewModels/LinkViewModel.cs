using System.ComponentModel.DataAnnotations;
namespace Authentication.ViewModels
{
    public class LinkViewModel
    {
        [Required(ErrorMessage = "A url é obrigatória")]
        public string Url { get; set; }

        [Required(ErrorMessage = "A urlShorted é obrigatória")]
        public string urlShorted { get; set; }
    }
}