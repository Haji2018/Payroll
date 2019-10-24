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

namespace PayrollApp.Areas.PayrollHr.Controllers
{
    [Area("PayrollHr")]
    [Authorize(Roles = "HR")]
    public class WorkerController : Controller
    {
        public PayrollDbContext _payrollDb { get; }

        public WorkerController(PayrollDbContext dbContext)
        {
            _payrollDb = dbContext;

        }

        [HttpGet]
        public async Task<JsonResult> WorkerSearch(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                List<Worker> employees = await _payrollDb.Workers.Include(a=>a.Employee).Where(e => e.Employee.Name.StartsWith(name))
                                                                        .ToListAsync();

                return Json(new { status = 200, data = employees });
            }
            return Json(new { status = 400 });
        }


        public IActionResult ListWorker()
        {


            ViewBag.TotalCount = _payrollDb.Workers.Count();
            var employees = _payrollDb.Workers.Include(c => c.Employee).Include(a=>a.Company).Include(q=>q.Department)
                .Include(w=>w.Store).Include(e=>e.Position).Include(e => e.PastPosition).OrderByDescending(x => x.Id).Take(4);


            return View(employees);
        }



        public IActionResult LoadMore(int skip)
        {
            var model = _payrollDb.Workers.Include(c => c.Employee).Include(a => a.Company).Include(q => q.Department)
                 .Include(w => w.Store).Include(e => e.Position).Include(e => e.PastPosition).OrderByDescending(x => x.Id).Skip(skip).Take(4);

            return PartialView("LoadMoreWorker", model);

        }


        [HttpGet]
        public  IActionResult  CreateWorker()
        {
       


            return View();
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWorker(Worker worker)
        {
        

            if (ModelState.IsValid)
            {
                Worker p = worker;
                await _payrollDb.Workers.AddAsync(p);
                await _payrollDb.SaveChangesAsync();
                return RedirectToAction(nameof(ListWorker));
            }
            else
            {
                return View();
            }
        }










        [HttpPost]
        public async Task<IActionResult> EditWorker(Worker worker, int id)
        {

            Worker worker1 = await _payrollDb.Workers.FindAsync(id);
            if (ModelState.IsValid)
            {
                if (worker1 != null)
                {

                    worker1.DepartmentId = worker.DepartmentId;
                    worker1.EmployeeId = worker.EmployeeId;
                    worker1.PositionId = worker.PositionId;
                    worker1.PastPositionId = worker.PastPositionId;
                    worker1.StoreId = worker.StoreId;
                    worker1.CompanyId = worker.CompanyId;
                    worker1.StartDate = worker.StartDate;
                 
                    await _payrollDb.SaveChangesAsync();

                    return RedirectToAction(nameof(ListWorker));


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
        public async Task<IActionResult> EditWorker(int id)
        {
            var departments = await _payrollDb.Departments.ToListAsync();
            ViewBag.Departments = departments;
            var employees = await _payrollDb.Employees.ToListAsync();
            ViewBag.Employees = employees;

            var companies = await _payrollDb.Companies.ToListAsync();
            ViewBag.Companies = companies;
            var positionss = await _payrollDb.PastPositions.ToListAsync();
            ViewBag.PastPositions = positionss;
            var positions = await _payrollDb.Positions.ToListAsync();
            ViewBag.Positions = positions;
            var stores = await _payrollDb.Stores.ToListAsync();
            ViewBag.Stores = stores;
            var worker = await _payrollDb.Workers.FindAsync(id);


            return View(worker);


        }




        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var data = await _payrollDb.Workers.FindAsync(id);

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
            var data = await _payrollDb.Workers.FindAsync(id);

            if (data != null)
            {
                _payrollDb.Workers.Remove(data);

                await _payrollDb.SaveChangesAsync();
            }

            return Json(new { companyDb = data, message = 200 });
        }




    }




}
