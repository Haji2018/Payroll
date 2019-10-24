
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayrollApp.Areas.PayrollAdmin.ViewModels;
using PayrollApp.Extensions;
using PayrollApp.Models.ForIdentity;
namespace PayrollApp.Areas.PayrollAdmin.Controllers
{
    [Area("PayrollAdmin")]
    //[Authorize(Roles = "Admin")]

    public class RoleController : Controller
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly SignInManager<ApplicationUser> _signInManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        public IHostingEnvironment hostingEnvironment { get; }

        public IRandomFileName randomFile { get; }


        public RoleController(UserManager<ApplicationUser> userManager,
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
        public IActionResult CreateRole()
        {
            return View();
        }


        

        [HttpPost]
       
        public async Task<IActionResult> AddPost(EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName

                };

                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {

                    return Json(new { departmantDb = result, message = 200 });


                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", errorMessage: "Bele Role Artiq Movcuddur");
                }

               
            }
            return Json(new { message = 400 });
        }



        [HttpGet]
        public async Task<JsonResult> Add(int? id)
        {
            if (id != null)
            {
                var data = await _roleManager.FindByIdAsync(id.ToString());

                if (data != null)
                {
                    return Json(new { companyDb = data, message = 200 });
                }
            }

            return Json(new { message = 400 });
        }




        [HttpGet]
        public IActionResult ListRole()
        {
            var roles = _roleManager.Roles;
            return View(roles);


        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);


            if (role == null)
            {
                return Redirect("~/Account/Error");

            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name,





            };

            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {

                    model.Users.Add(user.UserName);

                };
            }

            return View(model);


        }


        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);


            if (role == null)
            {
                 
                    return Redirect("~/Account/Error");

            }
            else

            {

                role.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {

                    return RedirectToAction(nameof(ListRole));

                }


                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", "Role Duuzgun Qeyd Edins");
                }


                return View(model);

            }

        }














      

        [HttpGet]
        public async Task<IActionResult> EditUsers(string id)
        {

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                  
                    return Redirect("~/Account/Error");
            

            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new RegisterViewModel
            {
                Id = user.Id,
                Email = user.Email,

                Image = user.Image,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Roles = userRoles

            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditUsers(RegisterViewModel model, IFormFile Image)
        {
            if (Image != null)
            {
                await Image.ImageSaverAsync(hostingEnvironment, model);
            }


            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                
                    return Redirect("~/Account/Error");

            }
            else
            {
              
                string rootPath = Path.Combine(hostingEnvironment.WebRootPath, "File", "Images");
                string imagePath = Path.Combine(rootPath, user.Image);
                IEnumerable<string> files = Directory.EnumerateFiles(rootPath);
                foreach (var image in files)
                {
                    if (image == imagePath)
                    {
                        await _userManager.UpdateAsync(user);

                    }
                }
                user.Email = model.Email;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                if (model.Image == null)
                    user.Image = user.Image;
                else
                    user.Image = model.Image;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers","Account");
                }
                return View(model);
            }
                 
           
           
        }

          
           

    
        [HttpGet]
        public async Task<IActionResult> ManageUserRole(string userId)
        {
            ViewBag.userId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest();
            }
            var model = new List<ManageUserRoleViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var manageUserRoleViewModel = new ManageUserRoleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                   manageUserRoleViewModel.IsSelected = true;
                }
                else
                {
                    manageUserRoleViewModel.IsSelected = false;
                }
                model.Add(manageUserRoleViewModel);
            }
           return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> ManageUserRole(List<ManageUserRoleViewModel> model, string userId)

        {


            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {


                return BadRequest();
            }


            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);


            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Rollari Duzgun qeyd edin");

                   return View(model);

            }

            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.IsSelected).Select(y => y.RoleName));



            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Rollari Duzgun qeyd edin");
                return View(model);
             }



            return RedirectToAction("EditUsers", new { Id = userId });


        }


        [HttpGet]
        public async Task<IActionResult> ChangePassword(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    var _passwordValidator =
                        HttpContext.RequestServices.GetService(typeof(IPasswordValidator<ApplicationUser>)) as IPasswordValidator<ApplicationUser>;
                    var _passwordHasher =
                        HttpContext.RequestServices.GetService(typeof(IPasswordHasher<ApplicationUser>)) as IPasswordHasher<ApplicationUser>;

                    IdentityResult result =
                        await _passwordValidator.ValidateAsync(_userManager, user, model.NewPassword);
                    if (result.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword);
                        await _userManager.UpdateAsync(user);
                        return RedirectToAction("ListUsers", "Account");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Istifadeci Tapilmadi");
                }
            }
            return View(model);
        }

    }
}

