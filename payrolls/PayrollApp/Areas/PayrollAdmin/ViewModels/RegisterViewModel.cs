using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApp.Areas.PayrollAdmin.ViewModels
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
            Roles = new List<string>();
        }
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Ad tələbolunandır")]
        [Display(Name = "Adı")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Soyad tələbolunandır")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        public string Image { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifrəniz")]

        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = " Təkrar Şifrəniz")]
        [Compare("Password", ErrorMessage = "Şifrəniz bir-biri ilə uyğun gəlmir")]
        public string ConfirmPassword { get; set; }


        
        public string RoleName { get; set; }


        public IList<string> Roles { get; set; }
    }
}
