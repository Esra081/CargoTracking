using System.ComponentModel.DataAnnotations;

namespace CargoTrackingg.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-posta adresi gerekli.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre gerekli.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
