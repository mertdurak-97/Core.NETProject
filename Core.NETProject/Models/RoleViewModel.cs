using System.ComponentModel.DataAnnotations;

namespace Core.NETProject.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Lütfen Rol Adını Giriniz !")]
        public string? name { get; set; }
    }
}
