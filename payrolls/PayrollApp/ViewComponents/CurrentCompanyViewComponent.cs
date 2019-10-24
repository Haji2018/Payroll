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
    public class CurrentCompanyViewComponent :ViewComponent
    {
        private readonly PayrollDbContext _context;

        public CurrentCompanyViewComponent(PayrollDbContext context)
        {
            _context = context;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            SelectListItemViewModel viewModel = new SelectListItemViewModel()
            {

                SelectListCompanies = await _context.Companies.Select(d => new SelectListItem
                {

                    Text = d.CompanyName,
                    Value = d.Id.ToString()



                }).ToListAsync(),

            };

            return View(viewModel);


        }

    }
}
