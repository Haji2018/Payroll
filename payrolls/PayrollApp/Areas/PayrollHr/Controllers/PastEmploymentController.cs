using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollApp.Models.DAL;
using PayrollApp.Models.Employment;

namespace PayrollApp.Areas.PayrollHr.Controllers
{
    [Area("PayrollHr")]
    [Authorize(Roles = "HR")]
    public class PastEmploymentController : Controller
    {
        public PayrollDbContext _payrollDb { get; }

        public PastEmploymentController(PayrollDbContext dbContext)
        {
            _payrollDb = dbContext;

        }



        public IEnumerable<PastEmployment> GetSearchResult(string searchString)
        {
            List<PastEmployment> data = new List<PastEmployment>();
            try
            {
                data = GetAllCompany().ToList();
                return data.Where(x => x.Employee.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<PastEmployment> GetAllCompany()
        {
            try
            {


                return _payrollDb.PastEmployments.Include(c => c.Employee).
             OrderByDescending(x => x.Id).Take(4);

            }
            catch
            {
                throw;
            }
        }
        public IActionResult ListPast(string searchString)
        {
            ViewBag.TotalCount = _payrollDb.PastEmployments.Count();
            var absents1 = _payrollDb.PastEmployments.ToList();
            ViewBag.PastEmployments = absents1;
            List<PastEmployment> absents = new List<PastEmployment>();
            absents = GetAllCompany().ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                absents = GetSearchResult(searchString).ToList();
            }

            return View(absents);
        }


        public IActionResult LoadMore(int skip)
        {
            var model = _payrollDb.PastEmployments.Include(b => b.Employee).OrderByDescending(x => x.Id).Skip(skip).Take(4);

            return PartialView("LoadMorePast", model);

        }

        [HttpGet]
        public  IActionResult CreatePast()
        {

          
            return View();
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePast(PastEmployment pastEmployment)
        {


            if (ModelState.IsValid)
            {
                PastEmployment p = pastEmployment;
                await _payrollDb.PastEmployments.AddAsync(p);
                await _payrollDb.SaveChangesAsync();
                return RedirectToAction(nameof(ListPast));
            }
            else
            {
                return View();
            }


        }










        [HttpGet]
        public async Task<IActionResult> EditPast(int id)
        {
            var employees = await _payrollDb.Employees.ToListAsync();
            ViewBag.Employees = employees;
            var pastEmployments = await _payrollDb.PastEmployments.FindAsync(id);


            return View(pastEmployments);
        }





        [HttpPost]
        public async Task<IActionResult> EditPast(PastEmployment pastEmployment, int id)
        {

            PastEmployment pastEmployment1 = await _payrollDb.PastEmployments.FindAsync(id);
            if (ModelState.IsValid)
            {
                if (pastEmployment1 != null)
                {


                    pastEmployment1.Company = pastEmployment.Company;
                    pastEmployment1.StartDate = pastEmployment.StartDate;
                    pastEmployment1.EndDate = pastEmployment.EndDate;
                    pastEmployment1.TheReasonForFailure = pastEmployment.Company;
                    pastEmployment1.EmployeeId = pastEmployment.EmployeeId;

                    await _payrollDb.SaveChangesAsync();

                    return RedirectToAction(nameof(ListPast));

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
                var data = await _payrollDb.PastEmployments.FindAsync(id);

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
            var data = await _payrollDb.PastEmployments.FindAsync(id);

            if (data != null)
            {
                _payrollDb.PastEmployments.Remove(data);

                await _payrollDb.SaveChangesAsync();
            }

            return Json(new { companyDb = data, message = 200 });
        }





    }
}