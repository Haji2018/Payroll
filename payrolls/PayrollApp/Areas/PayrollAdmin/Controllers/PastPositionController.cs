using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollApp.Models.DAL;
using PayrollApp.Models.Employment;

namespace PayrollApp.Areas.PayrollAdmin.Controllers
{
    [Area("PayrollAdmin")]
    [Authorize(Roles = "Admin")]
    public class PastPositionController : Controller
    {

        public PayrollDbContext _payrollDb { get; }

        public PastPositionController(PayrollDbContext dbContext)
        {
            _payrollDb = dbContext;

        }


        [HttpGet]
        public async Task<JsonResult> PastPositionSearch(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                List<PastPosition> employees = await _payrollDb.PastPositions.Where(e => e.PositionName.StartsWith(name))
                                                                        .ToListAsync();

                return Json(new { status = 200, data = employees });
            }
            return Json(new { status = 400 });
        }


        public IActionResult ListPastPosition()
        {

            ViewBag.TotalCount = _payrollDb.PastPositions.Count();
            var positions = _payrollDb.PastPositions.Include(c => c.Department).Include(a => a.Company).OrderByDescending(x => x.Id).Take(4);


            return View(positions);
        }




        [HttpGet]
        public IActionResult CreatePastPosition()
        {

            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePastPosition(PastPosition position)
        {


            if (ModelState.IsValid)
            {
                PastPosition p = position;
                await _payrollDb.PastPositions.AddAsync(p);
                await _payrollDb.SaveChangesAsync();
                return RedirectToAction(nameof(ListPastPosition));
            }
            else
            {
                return View();
            }


        }





        public IActionResult LoadMore(int skip)
        {
            var model = _payrollDb.PastPositions.Include(a => a.Department).Include(c => c.Company).OrderByDescending(x => x.Id).Skip(skip).Take(4);

            return PartialView("LoadMorePastPosition", model);

        }








        [HttpGet]
        public async Task<IActionResult> EditPastPosition(int id)
        {
            var companies = await _payrollDb.Companies.ToListAsync();
            ViewBag.Companies = companies;
            var departments = await _payrollDb.Departments.ToListAsync();
            ViewBag.Departments = departments;
            var position = await _payrollDb.PastPositions.FindAsync(id);
            return View(position);
        }




        [HttpPost]
        public async Task<IActionResult> EditPastPosition(PastPosition position, int id)
        {
            PastPosition position1 = await _payrollDb.PastPositions.FindAsync(id);
            if (ModelState.IsValid)
            {
                if (position1 != null)
                {

                    position1.PositionName = position.PositionName;
                    position1.PositionSalary = position.PositionSalary;
                    position1.DepartmentId = position.DepartmentId;
                    position1.CompanyId = position.CompanyId;
                    await _payrollDb.SaveChangesAsync();
                    return RedirectToAction(nameof(ListPastPosition));

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
                var data = await _payrollDb.PastPositions.FindAsync(id);

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
            var data = await _payrollDb.PastPositions.FindAsync(id);

            if (data != null)
            {
                _payrollDb.PastPositions.Remove(data);

                await _payrollDb.SaveChangesAsync();
            }

            return Json(new { companyDb = data, message = 200 });
        }
    }
}