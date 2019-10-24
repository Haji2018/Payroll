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
    public class VacationController : Controller
    {
        public PayrollDbContext _payrollDb { get; }

        public VacationController(PayrollDbContext dbContext)
        {
            _payrollDb = dbContext;

        }
        public IEnumerable<Vacation> GetSearchResult(string searchString)
        {
            List<Vacation> data = new List<Vacation>();
            try
            {
                data = GetAllCompany().ToList();
                return data.Where(x => x.Worker.Employee.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<Vacation> GetAllCompany()
        {
            try
            {


                return _payrollDb.Vacations.Include(c => c.Worker).ThenInclude(a => a.Employee).
             OrderByDescending(x => x.Id).Take(4);

            }
            catch
            {
                throw;
            }
        }
        public IActionResult ListVacation(string searchString)
        {
            ViewBag.TotalCount = _payrollDb.Vacations.Count();
            var vacations1 = _payrollDb.Vacations.ToList();
            ViewBag.Vacations = vacations1;
            List<Vacation> vacations = new List<Vacation>();
            vacations = GetAllCompany().ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                vacations = GetSearchResult(searchString).ToList();
            }

            return View(vacations);
        }






        public IActionResult LoadMore(int skip)
        {
            var model = _payrollDb.Vacations.Include(c => c.Worker).ThenInclude(a => a.Employee).OrderByDescending(x => x.Id).Skip(skip).Take(4);

            return PartialView("LoadMoreVacation", model);

        }


        [HttpGet]
        public IActionResult CreateVacation()
        {



            return View();
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVacation(Vacation vacation)
        {


            if (ModelState.IsValid)
            {
                Vacation p = vacation;
                await _payrollDb.Vacations.AddAsync(p);
                await _payrollDb.SaveChangesAsync();
                return RedirectToAction(nameof(ListVacation));
            }
            else
            {
                return View();
            }
        }











        [HttpPost]
        public async Task<IActionResult> EditVacation(Vacation vacation, int id)
        {

            Vacation vacation1 = await _payrollDb.Vacations.FindAsync(id);
            if (ModelState.IsValid)
            {

                if (vacation1 != null)
                {

                    vacation1.WorkerVacation = vacation.WorkerVacation;
                    vacation1.StartDate = vacation.StartDate;
                    vacation1.EndDate = vacation.EndDate;
                    vacation1.WorkerId = vacation.WorkerId;
                    await _payrollDb.SaveChangesAsync();

                    return RedirectToAction(nameof(ListVacation));


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
        public async Task<IActionResult> EditVacation(int id)
        {
            var workers = await _payrollDb.Workers.Include(c => c.Employee).ToListAsync();
            ViewBag.Workers = workers;
            var vacation = await _payrollDb.Vacations.FindAsync(id);


            return View(vacation);


        }







        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var data = await _payrollDb.Vacations.FindAsync(id);

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
            var data = await _payrollDb.Vacations.FindAsync(id);

            if (data != null)
            {
                _payrollDb.Vacations.Remove(data);

                await _payrollDb.SaveChangesAsync();
            }

            return Json(new { companyDb = data, message = 200 });
        }



    }
}