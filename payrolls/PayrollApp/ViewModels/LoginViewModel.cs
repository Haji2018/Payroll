﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApp.ViewModels
{
    public class LoginViewModel
    {


        [Required]
        [EmailAddress]
        public string Email { get; set; }

       

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifrəniz")]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }
}
