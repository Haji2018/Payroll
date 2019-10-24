using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollApp.Models.DAL;
using PayrollApp.Models.DepartmentHead;

namespace PayrollApp.Areas.PayrollDepartmentHead.Controllers
{
    [Area("PayrollDepartmentHead")]
    [Authorize(Roles = "DepartmentHeader")]
    public class WorkerPenaltyController : Controller
    {
        public PayrollDbContext _payrollDb { get; }

        public WorkerPenaltyController(PayrollDbContext dbContext)
        {
            _payrollDb = dbContext;

        }
        public IEnumerable<WorkerPenalty> GetSearchResult(string searchString)
        {
            List<WorkerPenalty> data = new List<WorkerPenalty>();
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
        public IEnumerable<WorkerPenalty> GetAllCompany()
        {
            try
            {


                return _payrollDb.WorkerPenalties.Include(c => c.Worker).ThenInclude(a => a.Employee).
             OrderByDescending(x => x.Id).Take(4);

            }
            catch
            {
                throw;
            }
        }
        public IActionResult ListWorkerPenalty(string searchString)
        {
            ViewBag.TotalCount = _payrollDb.WorkerPenalties.Count();
            var penaltyBonus1 = _payrollDb.WorkerPenalties.ToList();
            ViewBag.WorkerPenalties = penaltyBonus1;
            List<WorkerPenalty> stores = new List<WorkerPenalty>();
            stores = GetAllCompany().ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                stores = GetSearchResult(searchString).ToList();
            }

            return View(stores);
        }



        public IActionResult LoadMore(int skip)
        {

            var model = _payrollDb.WorkerPenalties.Include(c => c.Worker).ThenInclude(a => a.Employee).OrderByDescending(x => x.Id).Skip(skip).Take(4);
            return PartialView("LoadMoreWorkerPenalty", model);

        }

        [HttpGet]
        public IActionResult CreateWorkerPenalty()
        {


            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWorkerPenalty(WorkerPenalty penalty)
        {
            if (ModelState.IsValid)
            {

                WorkerPenalty p = penalty;

                await _payrollDb.WorkerPenalties.AddAsync(p);
                await _payrollDb.SaveChangesAsync();
                return RedirectToAction(nameof(ListWorkerPenalty));
            }

            return View(penalty);

        }




        [HttpGet]
        public async Task<IActionResult> EditWorkerPenalty(int id)
        {
            var model = await _payrollDb.Workers.Include(c => c.Employee).ToListAsync();
            ViewBag.Workers = model;
            var penalty = await _payrollDb.WorkerPenalties.FindAsync(id);

            return View(penalty);

        }
        [HttpPost]
        public async Task<IActionResult> EditWorkerPenalty(WorkerPenalty model, int id)
        {
            WorkerPenalty penalty = await _payrollDb.WorkerPenalties.FindAsync(id);


            if (ModelState.IsValid)
            {

                if (penalty != null) {


                    penalty.Amount = model.Amount;
                    penalty.PenaltyWritedDate = model.PenaltyWritedDate;
                    penalty.WorkerId = model.WorkerId;


                    await _payrollDb.SaveChangesAsync();
                    return RedirectToAction(nameof(ListWorkerPenalty));

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
                var data = await _payrollDb.WorkerPenalties.FindAsync(id);

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
            var data = await _payrollDb.WorkerPenalties.FindAsync(id);

            if (data != null)
            {
                _payrollDb.WorkerPenalties.Remove(data);

                await _payrollDb.SaveChangesAsync();
            }

            return Json(new { companyDb = data, message = 200 });
        }
    }
}