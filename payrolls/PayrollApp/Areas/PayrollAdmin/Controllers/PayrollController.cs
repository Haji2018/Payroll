﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayrollApp.Models.ForIdentity;

namespace PayrollApp.Areas.PayrollAdmin.Controllers
{
    [Area("PayrollAdmin")]
    [Authorize(Roles = "Admin")]
    public class PayrollController : Controller
    {


        public readonly SignInManager<ApplicationUser> _signInManager;



        public PayrollController(SignInManager<ApplicationUser> signInManager)
        {

            _signInManager = signInManager;

        }



     
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/Account/Login");
        }
    }
}