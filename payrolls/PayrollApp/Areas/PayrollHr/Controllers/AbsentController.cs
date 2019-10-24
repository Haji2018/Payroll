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
    public class AbsentController : Controller
    {
        public PayrollDbContext _payrollDb { get; }

        public AbsentController(PayrollDbContext dbContext)
        {
            _payrollDb = dbContext;

        }
        public IEnumerable<Absent> GetSearchResult(string searchString)
        {
            List<Absent> data = new List<Absent>();
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
        public IEnumerable<Absent> GetAllCompany()
        {
            try
            {


                return   _payrollDb.Absents.Include(c => c.Worker).ThenInclude(a => a.Employee).
             OrderByDescending(x => x.Id).Take(4);

            }
            catch
            {
                throw;
            }
        }
        public IActionResult ListAbsent(string searchString)
        {
            ViewBag.TotalCount = _payrollDb.Absents.Count();
            var absents1 = _payrollDb.Absents.ToList();
            ViewBag.Absents = absents1;
            List<Absent> absents = new List<Absent>();
            absents = GetAllCompany().ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                absents = GetSearchResult(searchString).ToList();
            }

            return View(absents);
        }


      



        public IActionResult LoadMore(int skip)
        {
            var model = _payrollDb.Absents.Include(c => c.Worker).ThenInclude(a => a.Employee).OrderByDescending(x => x.Id).Skip(skip).Take(4);

            return PartialView("LoadMoreAbsent", model);

        }


        [HttpGet]
        public  IActionResult CreateAbsent()
        {
         


            return View();
        }





        public int result;
        public int nese;
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAbsent(Absent absent)
        {
           

            if (ModelState.IsValid)
            {
                Absent p = absent;

                var workerAbsent = await _payrollDb.Absents.Where(x => x.WorkerId == p.WorkerId && x.Attandence == 0).ToListAsync();
                if (workerAbsent.Count == 5)
                {
 
                    foreach (var item in workerAbsent)
                    {
                       nese =   item.AbsentDate.Day;
                        result += nese;


                    }

                    if ((result % 5) == 0)
                    {
                        foreach (var item in workerAbsent)
                        {
                        
                            for (var i = 0; i < item.AbsentDate.Day; i++)
                            {
                                var nese = item.AbsentDate.Day;
                                if ((result / nese) == 5)
                                {
                                    
                                      return RedirectToAction("ListXitam","Xitam");

                                }


                            }
                        }
                       
                       

                    }


                }
                await _payrollDb.Absents.AddAsync(p);
                await _payrollDb.SaveChangesAsync();
                return RedirectToAction(nameof(ListAbsent));
            }
            else
            {
                return View();
            }
        }




     






        [HttpPost]
        public async Task<IActionResult> EditAbsent(Absent absent, int id)
        {

            Absent absent1 = await _payrollDb.Absents.FindAsync(id);
            if (ModelState.IsValid)
            {

                if (absent1 != null) {

                    absent1.Reason = absent.Reason;
                    absent1.AbsentDate = absent.AbsentDate;

                    absent1.WorkerId = absent.WorkerId;
                    await _payrollDb.SaveChangesAsync();

                    return RedirectToAction(nameof(ListAbsent));


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
        public async Task<IActionResult> EditAbsent(int id)
        {
            var workers = await _payrollDb.Workers.Include(c=>c.Employee).ToListAsync();
            ViewBag.Workers = workers;
            var absent = await _payrollDb.Absents.FindAsync(id);


            return View(absent);


        }







        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var data = await _payrollDb.Absents.FindAsync(id);

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
            var data = await _payrollDb.Absents.FindAsync(id);

            if (data != null)
            {
                _payrollDb.Absents.Remove(data);

                await _payrollDb.SaveChangesAsync();
            }

            return Json(new { companyDb = data, message = 200 });
        }



    }
}