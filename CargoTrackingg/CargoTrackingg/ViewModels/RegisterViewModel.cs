using System.ComponentModel.DataAnnotations;

namespace CargoTrackingg.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ad ve soyad gereklidir.")]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi girin.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı gereklidir.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Rol seçimi gereklidir.")]
        public string Role { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        public string? Position { get; set; }
        public string? Address { get; set; }
    }
}
