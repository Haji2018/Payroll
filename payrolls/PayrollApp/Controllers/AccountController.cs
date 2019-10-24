using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayrollApp.Models.ForIdentity;
using PayrollApp.ViewModels;

namespace PayrollApp.Controllers
{
    public class AccountController : Controller
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly SignInManager<ApplicationUser> _signInManager;


        public AccountController(UserManager<ApplicationUser> userManager,
                                   SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }




        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {


                var user = await _userManager.FindByNameAsync(model.Email);
                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);

                    foreach (var item in roles)
                    {
                        if (item == "Admin")
                        {
                            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.Remember, false);
                            if (result.Succeeded)
                                return RedirectToAction("Payroll", "PayrollAdmin");
                        }
                        if (item == "HR")
                        {

                            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.Remember, false);
                            if (result.Succeeded)
                                return RedirectToAction("Payroll", "PayrollHR");

                        }
                        if (item == "DepartmentHeader")
                        {

                            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.Remember, false);
                            if (result.Succeeded)
                                return RedirectToAction("Payroll", "PayrollDepartmentHead");

                        }
                        if (item == "Specialist")
                        {

                            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.Remember, false);
                            if (result.Succeeded)
                                return RedirectToAction("Payroll", "PayrollSpecialist");

                        }
                        else
                        {
                            return RedirectToAction("Login", "Account");


                        }

                    }
                }






                ModelState.AddModelError(string.Empty, " İstifadəçi movcud deyil");

            }

            return View(model);
        }





        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {


            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Error()
        {


            return View();
        }
    }




}