using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollApp.Extensions;
using PayrollApp.Models.DAL;
using PayrollApp.Models.Employment;

namespace PayrollApp.Areas.PayrollHr.Controllers
{
    [Area("PayrollHr")]
    [Authorize(Roles = "HR")]
    public class EmployeeController : Controller
    {
        public PayrollDbContext _payrollDb { get; }
        public IHostingEnvironment hostingEnvironment { get; }

        public IRandomFileName randomFile { get; }

      

        public EmployeeController(PayrollDbContext dbContext, IHostingEnvironment hosting, IRandomFileName randomFileName)
        {
            _payrollDb = dbContext;
            hostingEnvironment = hosting;
            randomFile = randomFileName;
        }



        [HttpGet]
        public async Task<JsonResult> EmployeeSearch(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                List<Employee> employees = await _payrollDb.Employees.Where(e => e.Name.StartsWith(name))
                                                                        .ToListAsync();

                return Json(new { status = 200, data = employees });
            }
            return Json(new { status = 400 });
        }


        public IActionResult ListEmployee()
        {
           

            ViewBag.TotalCount = _payrollDb.Employees.Count();
            var employees = _payrollDb.Employees.Include(c => c.Education).Include(a => a.FamilyStatus).Include(b=>b.Gender).OrderByDescending(x => x.Id).Take(4);


            return View(employees);
        }



        public IActionResult LoadMore(int skip)
        {
            var model = _payrollDb.Employees.Include(c => c.Education).Include(a => a.FamilyStatus).Include(b => b.Gender).OrderByDescending(x => x.Id).Skip(skip).Take(4);

            return PartialView("LoadMoreEmployee", model);

        }



        [HttpGet]
        public async Task<IActionResult> CreateEmployee()
        {
            var educations = await _payrollDb.Educations.ToListAsync();
            ViewBag.Educations = educations;
            var status = await _payrollDb.FamilyStatuses.ToListAsync();
            ViewBag.FamilyStatuses = status;
            var genders = await _payrollDb.Genders.ToListAsync();
            ViewBag.Genders = genders;
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEmployee(Employee employee, IFormFile Image)
        {
           

            if (Image == null)
            {
                ModelState.AddModelError("Image", "Image for post can't be empty");
                return View();
            }
            else { await Image.ImageSaverAsync(hostingEnvironment, employee); };

            if (ModelState.IsValid)
            {
                Employee p = employee;
                await _payrollDb.Employees.AddAsync(p);
                await _payrollDb.SaveChangesAsync();
                return RedirectToAction(nameof(ListEmployee));
            }
            else
                System.IO.File.Delete(hostingEnvironment.GetImagePathForDelete());

            return View();
        }




     




        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var educations = await _payrollDb.Educations.ToListAsync();
            ViewBag.Educations = educations;
            var status = await _payrollDb.FamilyStatuses.ToListAsync();
            ViewBag.FamilyStatuses = status;
            var genders = await _payrollDb.Genders.ToListAsync();
            ViewBag.Genders = genders;
            var employee1 = await _payrollDb.Employees.FindAsync(id);
            return View(employee1);
        }





        [HttpPost]
        public async Task<IActionResult> EditEmployee(Employee employee, IFormFile Image, int id)
        {
            if (Image != null)
            {
                await Image.ImageSaverAsync(hostingEnvironment, employee);
            }


            if (ModelState.IsValid)
            {
                var employee1 = await _payrollDb.Employees.FindAsync(id);



                string rootPath = Path.Combine(hostingEnvironment.WebRootPath, "File", "Images");
                string imagePath = Path.Combine(rootPath, employee1.Image);
                IEnumerable<string> files = Directory.EnumerateFiles(rootPath);

                foreach (var image in files)
                {
                    if (image == imagePath)
                    {
                        await _payrollDb.SaveChangesAsync();

                    }
                }

                if (employee1 != null)
                {


                    employee1.Name = employee.Name;
                    employee1.Surname = employee.Surname;
                    employee1.Patronymic = employee.Patronymic;
                    employee1.LivingPlace = employee.LivingPlace;
                    employee1.IdentityCardNumber = employee.IdentityCardNumber;

                    employee1.DistrictRegistration = employee.DistrictRegistration;
                    employee1.Birthday = employee.Birthday;
                    employee1.Education = employee.Education;
                    employee1.Gender = employee.Gender;
                    employee1.FamilyStatus = employee.FamilyStatus;
                    if (employee.Image == null)
                        employee1.Image = employee1.Image;
                    else
                        employee1.Image = employee.Image;



                    await _payrollDb.SaveChangesAsync();


                }
                else
                    return Redirect("~/Account/Error");

            }
            else
                System.IO.File.Delete(hostingEnvironment.GetImagePathForDelete());
            return RedirectToAction(nameof(ListEmployee));
        

    }



       
        [HttpGet]
        public async Task<JsonResult> Details(int? id)
        {
            if (id != null)
            {
                var data = await _payrollDb.Employees.FindAsync(id);

                if (data != null)
                {
                    return Json(new { companyDb = data, message = 200 });
                }
            }

            return Json(new { message = 400 });
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var data = await _payrollDb.Employees.FindAsync(id);

                if (data != null)
                {
                    return Json(new { companyDb = data, message = 200 });
                }
            }

            return Json(new { message = 400 });
        }
        [HttpPost]

        public async Task<IActionResult> DeletePost(int? id)
        {
            var data = await _payrollDb.Employees.FindAsync(id);

            if (data != null)
            {
                _payrollDb.Employees.Remove(data);

                await _payrollDb.SaveChangesAsync();
            }

            return Json(new { companyDb = data, message = 200 });
        }

    }
}

