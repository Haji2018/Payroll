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

namespace PayrollApp.Areas.PayrollAdmin.Controllers
{
    [Area("PayrollAdmin")]
    [Authorize(Roles = "Admin")]
    public class StoreController : Controller
    {
        public PayrollDbContext _payrollDb { get; }

        public StoreController(PayrollDbContext dbContext)
        {
            _payrollDb = dbContext;

        }

        [HttpGet]
        public async Task<JsonResult> StoreSearch(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                List<Store> employees = await _payrollDb.Stores.Where(e => e.StoreName.StartsWith(name))
                                                                        .ToListAsync();

                return Json(new { status = 200, data = employees });
            }
            return Json(new { status = 400 });
        }





        [HttpGet]
        public async Task<IActionResult>  CreateStore()
        {
            var departmens = await _payrollDb.Departments.ToListAsync();
            ViewBag.Departments = departmens;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStore(Store store)
        {
            

         
            if (ModelState.IsValid)
            {
                Store p = store;
                await _payrollDb.Stores.AddAsync(p);
                await _payrollDb.SaveChangesAsync();

                return RedirectToAction(nameof(ListStore));


            }
            else
            {

                return View();
            }
        }



        public IActionResult  ListStore()
        {
            ViewBag.TotalCount = _payrollDb.Stores.Count();
            var store = _payrollDb.Stores.Include(c => c.Department).OrderByDescending(x => x.Id).Take(4);
           

            return View(store);
       }


        public IActionResult LoadMore(int skip)
        {
            var model = _payrollDb.Stores.Include(c => c.Department).OrderByDescending(x => x.Id).Skip(skip).Take(4);

            return PartialView("LoadMoreStore", model);

        }




        [HttpGet]
        public async Task<IActionResult> EditStore(int id)
        {
            var departmens = await _payrollDb.Departments.ToListAsync();
            ViewBag.Departments = departmens;
            var store = await _payrollDb.Stores.FindAsync(id);



            return View(store);
        }





        [HttpPost]
        public async Task<IActionResult> EditStore(Store store,int id)
        {
          
           
            Store store1 = await  _payrollDb.Stores.FindAsync(id);
            if (ModelState.IsValid)
            {
                if (store1 != null) {


                    store1.StoreName = store.StoreName;
                    store1.Address = store.Address;
                    store1.Phone = store.Phone;
                    store1.DepartmentId = store.DepartmentId;

                    await _payrollDb.SaveChangesAsync();

                    return RedirectToAction(nameof(ListStore));


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
                var data = await _payrollDb.Stores.FindAsync(id);

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
            var data = await _payrollDb.Stores.FindAsync(id);

            if (data != null)
            {
                _payrollDb.Stores.Remove(data);

                await _payrollDb.SaveChangesAsync();
            }

            return Json(new { companyDb = data, message = 200 });
        }



    }
}