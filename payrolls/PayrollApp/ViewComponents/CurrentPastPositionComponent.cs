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
    public class CurrentPastPositionViewComponent : ViewComponent
    {
        private readonly PayrollDbContext _context;

        public CurrentPastPositionViewComponent(PayrollDbContext context)
        {
            _context = context;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            SelectListItemViewModel viewModel = new SelectListItemViewModel()
            {

                SelectListPositions = await _context.PastPositions.Select(d => new SelectListItem
                {

                    Text = d.PositionName,
                    Value = d.Id.ToString()



                }).ToListAsync(),

            };

            return View(viewModel);


        }
    }
}
