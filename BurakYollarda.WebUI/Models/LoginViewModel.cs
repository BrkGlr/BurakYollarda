using System.ComponentModel.DataAnnotations;

namespace BurakYollarda.WebUI.Models
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Lütfen Email Adresi Giriniz.")]
        public string Email { get; set; }

        [Display(Name ="Şifre")]
        [Required(ErrorMessage = "Lütfen Şifre Giriniz.")]
        public string Password { get; set; }
    }
}
