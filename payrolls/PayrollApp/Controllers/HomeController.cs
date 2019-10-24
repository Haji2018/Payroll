using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PayrollApp.Models.DAL;

namespace PayrollApp.Controllers
{
    public class HomeController : Controller
    {



        public PayrollDbContext _payrollDb { get; }
      



        public HomeController(PayrollDbContext dbContext)
        {
            _payrollDb = dbContext;
         
        }



        public IActionResult Index()
        {
            return View(_payrollDb.Employees.ToList());
        }
    }
}