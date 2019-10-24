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
    public class CurrentHoldingViewComponent : ViewComponent
    {

        private readonly PayrollDbContext _context;

        public CurrentHoldingViewComponent(PayrollDbContext context)
        {
            _context = context;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            SelectListItemViewModel viewModel = new SelectListItemViewModel()
            {

                SelectListHoldings = await _context.Holdings.Select(d => new SelectListItem
                {

                    Text = d.HoldingName,
                    Value = d.Id.ToString()



                }).ToListAsync(),

            };

            return View(viewModel);
        

        }
           

        
    }
}
