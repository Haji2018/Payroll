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
    public class XitamController : Controller
    {
        public PayrollDbContext _payrollDb { get; }

        public XitamController(PayrollDbContext dbContext)
        {
            _payrollDb = dbContext;

        }
        public IEnumerable<Xitam> GetSearchResult(string searchString)
        {
            List<Xitam> data = new List<Xitam>();
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
        public IEnumerable<Xitam> GetAllCompany()
        {
            try
            {


                return _payrollDb.Xitams.Include(c => c.Worker).ThenInclude(a => a.Employee).
             OrderByDescending(x => x.Id).Take(4);

            }
            catch
            {
                throw;
            }
        }
        public IActionResult ListXitam(string searchString)
        {
            ViewBag.TotalCount = _payrollDb.Xitams.Count();
            var xitam1 = _payrollDb.Xitams.ToList();
            ViewBag.Xitams = xitam1;
            List<Xitam> xitams = new List<Xitam>();
            xitams = GetAllCompany().ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                xitams = GetSearchResult(searchString).ToList();
            }

            return View(xitams);
        }






        public IActionResult LoadMore(int skip)
        {
            var model = _payrollDb.Xitams.Include(c => c.Worker).ThenInclude(a => a.Employee).OrderByDescending(x => x.Id).Skip(skip).Take(4);

            return PartialView("LoadMoreXitam", model);

        }


        [HttpGet]
        public IActionResult CreateXitam()
        {



            return View();
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateXitam(Xitam xitam)
        {


            if (ModelState.IsValid)
            {
                Xitam p = xitam;
                await _payrollDb.Xitams.AddAsync(p);
                await _payrollDb.SaveChangesAsync();
                return RedirectToAction(nameof(ListXitam));
            }
            else
            {
                return View();
            }
        }











        [HttpPost]
        public async Task<IActionResult> EditXitam(Xitam xitam, int id)
        {

            Xitam xitam1 = await _payrollDb.Xitams.FindAsync(id);
            if (ModelState.IsValid)
            {

                if (xitam1 != null)
                {

                   
                    xitam1.EndDate = xitam.EndDate;

                    xitam1.WorkerId = xitam.WorkerId;
                    await _payrollDb.SaveChangesAsync();

                    return RedirectToAction(nameof(ListXitam));


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
        public async Task<IActionResult> EditXitam(int id)
        {
            var workers = await _payrollDb.Workers.Include(c => c.Employee).ToListAsync();
            ViewBag.Workers = workers;
            var absent = await _payrollDb.Xitams.FindAsync(id);


            return View(absent);


        }







        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var data = await _payrollDb.Xitams.FindAsync(id);

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
            var data = await _payrollDb.Xitams.FindAsync(id);

            if (data != null)
            {
                _payrollDb.Xitams.Remove(data);

                await _payrollDb.SaveChangesAsync();
            }

            return Json(new { companyDb = data, message = 200 });
        }



    }
}