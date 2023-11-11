using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    public class LoginViewModel
    {
        [Required, MinLength(2, ErrorMessage = "Minimum length is 2")]
        [Display(Name = "UserName")]
        public string Email { get; set; }

        [DataType(DataType.Password), Required, MinLength(4, ErrorMessage = "Minimum length is 4")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
