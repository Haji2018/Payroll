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
using PayrollApp.Models.Head;

namespace PayrollApp.Areas.PayrollAdmin.Controllers
{
    [Area("PayrollAdmin")]
    [Authorize(Roles = "Admin")]
    public class CompanyController : Controller
    {
        public PayrollDbContext _payrollDb { get; }

        public CompanyController(PayrollDbContext dbContext)
        {
            _payrollDb = dbContext;

        }

        [HttpGet]
        public async Task<JsonResult> CompanySearch(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                List<Company> employees = await _payrollDb.Companies.Where(e => e.CompanyName.StartsWith(name))
                                                                        .ToListAsync();

                return Json(new { status = 200, data = employees });
            }
            return Json(new { status = 400 });
        }

        public  IActionResult  ListCompany()
        {



            ViewBag.TotalCount = _payrollDb.Companies.Count();
            var companies =  _payrollDb.Companies.Include(x=>x.Holding).OrderByDescending(x=>x.Id).Take(4);

            return View(companies);

          
        }




        public  IActionResult LoadMore(int skip)
        {



            
            var model =  _payrollDb.Companies.Include(x => x.Holding).OrderByDescending(x => x.Id).Skip(skip).Take(4);


            return PartialView("LoadMoreCompany", model);
        


        }
        [HttpGet]
        public IActionResult CreateCompany()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCompany(Company company)
        {


            if (ModelState.IsValid)
            {
                Company p = company;
                await _payrollDb.Companies.AddAsync(p);
                await _payrollDb.SaveChangesAsync();
                return RedirectToAction(nameof(ListCompany));
            }
            else
            {
                return View();
            }
        }







        [HttpGet]
        public async Task<JsonResult> AddOrEdit(int? id)
        {
            if (id != null)
            {
                var data = await _payrollDb.Companies.FindAsync(id);

                if (data != null)
                {
                    return Json(new { companyDb = data, message = 200 });
                }
            }

            return Json(new { message = 400 });
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id, Company model)
        {
            var data = await _payrollDb.Companies.FindAsync(id);

            if (data == null) return View();

            if (data != null)
            {
                data.CompanyName = model.CompanyName;
                data.Address = model.Address;
                data.Phone = model.Phone;
                data.About = model.About;
                data.HoldingId = model.HoldingId;
                await _payrollDb.SaveChangesAsync();

                return Json(new { departmantDb = data, message = 200 });
            }

            return Json(new { message = 400 });

        }



        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var data = await _payrollDb.Companies.FindAsync(id);

                if (data != null)
                {
                    return Json(new { companyDb = data, message = 200 });
                }
            }

            return Json(new { message = 400 });
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            var data = await _payrollDb.Companies.FindAsync(id);

            if (data != null)
            {
                _payrollDb.Companies.Remove(data);

                await _payrollDb.SaveChangesAsync();
            }

            return Json(new { companyDb = data, message = 200 });
        }


      


    }
}
