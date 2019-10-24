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
    public class PositionController : Controller
    {
        
        public PayrollDbContext _payrollDb { get; }

        public PositionController(PayrollDbContext dbContext)
        {
            _payrollDb = dbContext;

        }


        [HttpGet]
        public async Task<JsonResult> PositionSearch(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                List<Position> employees = await _payrollDb.Positions.Where(e => e.PositionName.StartsWith(name))
                                                                        .ToListAsync();

                return Json(new { status = 200, data = employees });
            }
            return Json(new { status = 400 });
        }


        public IActionResult ListPosition()
        {

            ViewBag.TotalCount = _payrollDb.Positions.Count();
            var positions = _payrollDb.Positions.Include(c => c.Department).Include(a=>a.Company).OrderByDescending(x => x.Id).Take(4);


            return View(positions);
        }




        [HttpGet]
        public   IActionResult CreatePosition()
        {
        
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePosition(Position position)
        {
         

            if (ModelState.IsValid)
            {
                Position p = position;
                await _payrollDb.Positions.AddAsync(p);
                await _payrollDb.SaveChangesAsync();
                return RedirectToAction(nameof(ListPosition));
            }
            else
            {
                return View();
            }


        }





        public IActionResult LoadMore(int skip)
        {
            var model = _payrollDb.Positions.Include(a=>a.Department).Include(c => c.Company).OrderByDescending(x => x.Id).Skip(skip).Take(4);

            return PartialView("LoadMorePosition", model);

        }








        [HttpGet]
        public async Task<IActionResult> EditPosition(int id)
        {
            var companies = await _payrollDb.Companies.ToListAsync();
            ViewBag.Companies = companies;
            var departments = await _payrollDb.Departments.ToListAsync();
            ViewBag.Departments = departments;
            var position = await _payrollDb.Positions.FindAsync(id);
            return View(position);
        }




        [HttpPost]
        public async Task<IActionResult> EditPosition(Position position, int id)
        {
            Position position1 = await _payrollDb.Positions.FindAsync(id);
            if (ModelState.IsValid)
            {
                if (position1 != null) {

                    position1.PositionName = position.PositionName;
                    position1.PositionSalary = position.PositionSalary;
                    position1.DepartmentId = position.DepartmentId;
                    position1.CompanyId = position.CompanyId;
                    await _payrollDb.SaveChangesAsync();
                    return RedirectToAction(nameof(ListPosition));

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
                var data = await _payrollDb.Positions.FindAsync(id);

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
            var data = await _payrollDb.Positions.FindAsync(id);

            if (data != null)
            {
                _payrollDb.Positions.Remove(data);

                await _payrollDb.SaveChangesAsync();
            }

            return Json(new { companyDb = data, message = 200 });
        }
    }
}
