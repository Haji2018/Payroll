using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PayrollApp.Areas.PayrollAdmin.ViewModels;
using PayrollApp.Extensions;
using PayrollApp.Models.ForIdentity;

namespace PayrollApp.Areas.PayrollAdmin.Controllers
{
    [Area("PayrollAdmin")]
    //[Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly SignInManager<ApplicationUser> _signInManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        public IHostingEnvironment hostingEnvironment { get; }

        public IRandomFileName randomFile { get; }


        public AccountController(UserManager<ApplicationUser> userManager,
                                   SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
             IHostingEnvironment _hostingEnvironment,
            IRandomFileName _randomFile)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            hostingEnvironment = _hostingEnvironment;
            randomFile = _randomFile;
        }


          [HttpGet]
     
        public IActionResult ListUsers()
        {

          

            var users = _userManager.Users;
           
            return View(users);
        }

    


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            ViewBag.Roles = new SelectList(_roleManager.Roles, "Name", "Name");
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  Register(RegisterViewModel model, IFormFile Image)



        {
            if (Image == null)
            {
                ModelState.AddModelError("Image", "Image for post can't be empty");
                return View();
            }
            else { await Image.ImageSaverAsync(hostingEnvironment, model); };




            var user = new ApplicationUser
            {           
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Image = model.Image
              
            };

            var result = await _userManager.CreateAsync(user, model.Password);         
            if (result.Succeeded)
            {          
               await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction(nameof(ListUsers));
            }
            else
                System.IO.File.Delete(hostingEnvironment.GetImagePathForDelete());
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            
          
            return View(model);
        }
    }
    
   


}