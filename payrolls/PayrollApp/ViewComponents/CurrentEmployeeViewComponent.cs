using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PayrollApp.Models.DAL;
using PayrollApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApp.ViewComponents
{
    public class CurrentEmployeeViewComponent : ViewComponent

    {

        private readonly PayrollDbContext _context;

        public CurrentEmployeeViewComponent(PayrollDbContext context)
        {
            _context = context;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            SelectListItemViewModel viewModel = new SelectListItemViewModel()
            {

                SelectListEmployees = await _context.Employees.Select(d => new SelectListItem
                {

                    Text = d.Name + " " + d.Surname,
                    Value = d.Id.ToString()



                }).ToListAsync(),

            };

            return View(viewModel);


        }

    }
}
