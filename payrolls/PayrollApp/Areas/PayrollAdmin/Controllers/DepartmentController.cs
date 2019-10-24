using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollApp.Extensions;
using PayrollApp.Models.DAL;
using PayrollApp.Models.Employment;
using PayrollApp.Models.Library;

namespace PayrollApp.Areas.PayrollAdmin.Controllers
{
    [Area("PayrollAdmin")]
    [Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
        {
            public PayrollDbContext _payrollDb { get; }

            public DepartmentController(PayrollDbContext dbContext)
            {
                _payrollDb = dbContext;

            }


        [HttpGet]
        public async Task<JsonResult> DepartmentSearch(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                List<Department> employees = await _payrollDb.Departments.Where(e => e.DepartmentName.StartsWith(name))
                                                                        .ToListAsync();

                return Json(new { status = 200, data = employees });
            }
            return Json(new { status = 400 });
        }


        public IActionResult ListDepartment()
        {

            ViewBag.TotalCount = _payrollDb.Departments.Count();
            var departments = _payrollDb.Departments.Include(c=>c.Company).OrderByDescending(x => x.Id).Take(4);
           

            return View(departments);
        }
        public IActionResult LoadMore(int skip)
        {
            var model = _payrollDb.Departments.Include(c => c.Company).OrderByDescending(x => x.Id).Skip(skip).Take(4);

            return PartialView("LoadMoreDepartment", model);

        }
        [HttpGet]
        public  IActionResult CreateDepartment()
        {

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDepartment(Department department)
        {
           

            if (ModelState.IsValid)
            {
                Department p = department;
                await _payrollDb.Departments.AddAsync(p);
                await _payrollDb.SaveChangesAsync();
                return RedirectToAction(nameof(ListDepartment));
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditDepartment(int id)
        {

            var company = await _payrollDb.Companies.ToListAsync();
            ViewBag.Companies = company;
            var department = await _payrollDb.Departments.FindAsync(id);
            return View(department);
        }




        [HttpPost]
        public async Task<IActionResult> EditDepartment(Department department, int id)
        {
            Department department1 = await _payrollDb.Departments.FindAsync(id);
            if (ModelState.IsValid)
            {
                if (department1 != null)
                {

                    department1.DepartmentName = department.DepartmentName;
                    department1.Phone = department.Phone;
                    department1.CompanyId = department.CompanyId;

                    await _payrollDb.SaveChangesAsync();
                    return RedirectToAction(nameof(ListDepartment));


                }
                else                  
                return Redirect("~/Account/Error");
            }
            else
            {
                return View();
            }

        }




        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var data = await _payrollDb.Departments.FindAsync(id);

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
            var data = await _payrollDb.Departments.FindAsync(id);

            if (data != null)
            {
                _payrollDb.Departments.Remove(data);

                await _payrollDb.SaveChangesAsync();
            }

            return Json(new { companyDb = data, message = 200 });
        }


      









    }
}
