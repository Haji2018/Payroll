using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollApp.Areas.PayrollAdmin.ViewModels;
using PayrollApp.Models.DAL;
using PayrollApp.Models.Head;

namespace PayrollApp.Areas.PayrollAdmin.Controllers
{
    [Area("PayrollAdmin")]
    [Authorize(Roles = "Admin")]
    public class HoldingController : Controller
    {
        public PayrollDbContext _payrollDb { get; }

        public HoldingController(PayrollDbContext dbContext)
        {
            _payrollDb = dbContext;

        }

        [HttpGet]
        public async Task<JsonResult> HoldingSearch(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                List<Holding> employees = await _payrollDb.Holdings.Where(e => e.HoldingName.StartsWith(name))
                                                                        .ToListAsync();

                return Json(new { status = 200, data = employees });
            }
            return Json(new { status = 400 });
        }


        public  IActionResult ListHolding()
        {
            ViewBag.TotalCount = _payrollDb.Holdings.Count();
            var holding = _payrollDb.Holdings.OrderByDescending(x => x.Id).Take(4);

            return View(holding);
        }

        public IActionResult LoadMore(int skip)
        {
            var model   = _payrollDb.Holdings.OrderByDescending(x => x.Id).Skip(skip).Take(4);

            return PartialView("LoadMorePartial", model);

        }



        [HttpGet]
        public  IActionResult CreateHolding()
        {
          
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHolding(Holding holding)
        {



            if (ModelState.IsValid)
            {
                Holding p = holding;
                await _payrollDb.Holdings.AddAsync(p);
                await _payrollDb.SaveChangesAsync();

                return RedirectToAction(nameof(ListHolding));


            }
            else
            {

                return View();
            }
        }




        [HttpGet]
        public async Task<JsonResult> Edit(int? id)
        {
            if (id != null)
            {
                var data = await _payrollDb.Holdings.FindAsync(id);

                if (data != null)
                {
                    return Json(new { companyDb = data, message = 200 });
                }
            }

            return Json(new { message = 400 });
        }


        [HttpPost]
        public async Task<IActionResult> EditPost(int? id, Holding model)
        {
            var data = await _payrollDb.Holdings.FindAsync(id);

            if (data == null) return View();

            if (data != null)
            {
                data.HoldingName = model.HoldingName;
                data.Address = model.Address;
                data.Phone = model.Phone;
                data.About = model.About;
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
                var data = await _payrollDb.Holdings.FindAsync(id);

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
            var data = await _payrollDb.Holdings.FindAsync(id);

            if (data != null)
            {
                _payrollDb.Holdings.Remove(data);

                await _payrollDb.SaveChangesAsync();
            }

            return Json(new { companyDb = data, message = 200 });
        }



    }
}


   