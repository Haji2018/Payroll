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
    public class WorkerBonusController : Controller
    {
        public PayrollDbContext _payrollDb { get; }

        public WorkerBonusController(PayrollDbContext dbContext)
        {
            _payrollDb = dbContext;

        }

        public IEnumerable<WorkerBonus> GetSearchResult(string searchString)
        {
            List<WorkerBonus> data = new List<WorkerBonus>();
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
        public IEnumerable<WorkerBonus> GetAllCompany()
        {
            try
            {


                return _payrollDb.WorkerBonuses.Include(c => c.Worker).ThenInclude(a=>a.Employee).
             OrderByDescending(x => x.Id).Take(4);

            }
            catch
            {
                throw;
            }
        }
        public IActionResult ListWorkerBonus(string searchString)
        {
            ViewBag.TotalCount = _payrollDb.WorkerBonuses.Count();
            var workerBonus1 = _payrollDb.WorkerBonuses.ToList();
            ViewBag.WorkerBonuses = workerBonus1;
            List<WorkerBonus> stores = new List<WorkerBonus>();
            stores = GetAllCompany().ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                stores = GetSearchResult(searchString).ToList();
            }

            return View(stores);
        }


        public IActionResult LoadMore(int skip)
        {

            var model = _payrollDb.WorkerBonuses.Include(c => c.Worker).ThenInclude(a => a.Employee).OrderByDescending(x => x.Id).Skip(skip).Take(4);
            return PartialView("LoadMoreWorkerBonus", model);

        }

        [HttpGet]
        public IActionResult CreateWorkerBonus()
        {


            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWorkerBonus(WorkerBonus bonus)
        {
            if (ModelState.IsValid)
            {

                WorkerBonus p = bonus;

                await _payrollDb.WorkerBonuses.AddAsync(p);
                await _payrollDb.SaveChangesAsync();
                return RedirectToAction(nameof(ListWorkerBonus));
            }

            return View(bonus);

        }




        [HttpGet]
        public async Task<IActionResult> EditWorkerBonus(int id)
        {
            var model = await _payrollDb.Workers.Include(c => c.Employee).ToListAsync();
            ViewBag.Workers = model;
            var bonus = await _payrollDb.WorkerBonuses.FindAsync(id);

            return View(bonus);

        }
        [HttpPost]
        public async Task<IActionResult> EditWorkerBonus(WorkerBonus model, int id)
        {
            WorkerBonus bonus = await _payrollDb.WorkerBonuses.FindAsync(id);


            if (ModelState.IsValid)
            {
                if (bonus != null)
                {


                    bonus.Amount = model.Amount;
                    bonus.BonusWritedDate = model.BonusWritedDate;
                    bonus.WorkerId = model.WorkerId;


                    await _payrollDb.SaveChangesAsync();
                    return RedirectToAction(nameof(ListWorkerBonus));

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
                var data = await _payrollDb.WorkerBonuses.FindAsync(id);

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
            var data = await _payrollDb.WorkerBonuses.FindAsync(id);

            if (data != null)
            {
                _payrollDb.WorkerBonuses.Remove(data);

                await _payrollDb.SaveChangesAsync();
            }

            return Json(new { companyDb = data, message = 200 });
        }


    }
}