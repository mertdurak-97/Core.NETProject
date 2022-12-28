using System.ComponentModel.DataAnnotations;

namespace Core.NETProject.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Girin")]
        public string? LoginUserName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Girin")]
        public string? LoginPassword { get; set; }
    }
}
