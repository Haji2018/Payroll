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
    public class StoreBonusController : Controller
    {
        public PayrollDbContext _payrollDb { get; }

        public StoreBonusController(PayrollDbContext dbContext)
        {
            _payrollDb = dbContext;

        }



        public IEnumerable<StoreBonus> GetSearchResult(string searchString)
        {
            List<StoreBonus> data = new List<StoreBonus>();
            try
            {
                data = GetAllCompany().ToList();
                return data.Where(x => x.Store.StoreName.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<StoreBonus> GetAllCompany()
        {
            try
            {


                return _payrollDb.StoreBonuses.Include(c => c.Store).
             OrderByDescending(x => x.Id).Take(4);

            }
            catch
            {
                throw;
            }
        }
        public IActionResult ListStoreBonus(string searchString)
        {
            ViewBag.TotalCount = _payrollDb.StoreBonuses.Count();
            var storeBonus1 = _payrollDb.StoreBonuses.ToList();
            ViewBag.StoreBonuses = storeBonus1;
            List<StoreBonus> stores = new List<StoreBonus>();
            stores = GetAllCompany().ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                stores = GetSearchResult(searchString).ToList();
            }

            return View(stores);
        }


        public IActionResult LoadMore(int skip)
        {
          
            var model = _payrollDb.StoreBonuses.Include(c => c.Store).OrderByDescending(x => x.Id).Skip(skip).Take(4);
            return PartialView("LoadMoreStoreBonus", model);

        }

        [HttpGet]
        public  IActionResult  CreateStoreBonus()
        {
       

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStoreBonus(StoreBonus bonus)
        {
            if (ModelState.IsValid)
            {

                StoreBonus p = bonus;

                await _payrollDb.StoreBonuses.AddAsync(p);
                await _payrollDb.SaveChangesAsync();
                return RedirectToAction(nameof(ListStoreBonus));
            }

            return View(bonus);

        }

       


        [HttpGet]
        public async Task<IActionResult> EditStoreBonus(int id)
        {
            var store = await _payrollDb.Stores.ToListAsync();
            ViewBag.Stores = store;
            var bonus = await _payrollDb.StoreBonuses.FindAsync(id);

            return View(bonus);

        }
        [HttpPost]
        public async Task<IActionResult> EditStoreBonus(StoreBonus model, int id)
        {
            StoreBonus bonus = await _payrollDb.StoreBonuses.FindAsync(id);


            if (ModelState.IsValid)
            {
                if (bonus != null)
                {

                    bonus.Amount = model.Amount;
                    bonus.Month = model.Month;
                    bonus.StoreId = model.StoreId;
                    bonus.StoreBonusWritedDate = model.StoreBonusWritedDate;

                    await _payrollDb.SaveChangesAsync();
                    return RedirectToAction(nameof(ListStoreBonus));

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
                var data = await _payrollDb.StoreBonuses.FindAsync(id);

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
            var data = await _payrollDb.StoreBonuses.FindAsync(id);

            if (data != null)
            {
                _payrollDb.StoreBonuses.Remove(data);

                await _payrollDb.SaveChangesAsync();
            }

            return Json(new { companyDb = data, message = 200 });
        }


    }
}