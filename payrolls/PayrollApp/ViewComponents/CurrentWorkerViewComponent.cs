using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using PayrollApp.Models.DAL;
using PayrollApp.Models.Employment;
using PayrollApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApp.ViewComponents
{
    public class CurrentWorkerViewComponent : ViewComponent
    {
        private readonly PayrollDbContext _context;

        public CurrentWorkerViewComponent(PayrollDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            SelectListItemViewModel viewModel = new SelectListItemViewModel
            {
                SelectListWorkers = await _context.Workers.Select(d => new SelectListItem
                {
                    Text = d.Employee.Name + " " + d.Employee.Surname,
                    Value = d.Id.ToString()
                }).ToListAsync(),
               
            };

            return View(viewModel);
        }
    }
}

