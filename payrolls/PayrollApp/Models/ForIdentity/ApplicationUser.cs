using Microsoft.AspNetCore.Identity;
using PayrollApp.Models.Employment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApp.Models.ForIdentity
{
    public class ApplicationUser : IdentityUser
    {



        [Required(ErrorMessage = "Ad qeyd olunmalıdır.")]
        [StringLength(40, ErrorMessage = "Zəhmət olmasa  adın uzunluğunu düzgün yazın.")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad qeyd olunmalıdır.")]
        [StringLength(40, ErrorMessage = "Zəhmət olmasa  soyadın uzunluğunu düzgün yazın.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }



        [Display(Name = "Şəkil")]
        public string Image { get; set; }



       
    }
}
