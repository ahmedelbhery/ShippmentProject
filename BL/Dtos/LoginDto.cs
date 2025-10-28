using AppResources;
using System.ComponentModel.DataAnnotations;

namespace BL.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessageResourceType = typeof(Shipping), ErrorMessageResourceName = "EmailRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(Shipping), ErrorMessageResourceName = "InvalidEmail")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Shipping), ErrorMessageResourceName = "PasswordRequired")]
        [MinLength(6, ErrorMessageResourceType = typeof(Shipping), ErrorMessageResourceName = "PasswordMinLength")]
        public string Password { get; set; }
    }
}
