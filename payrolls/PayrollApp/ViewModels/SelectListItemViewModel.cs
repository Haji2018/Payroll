using Microsoft.AspNetCore.Mvc.Rendering;
using PayrollApp.Models.Employment;
using PayrollApp.Models.Head;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApp.ViewModels
{
    public class SelectListItemViewModel
    {
        public List<SelectListItem> SelectListWorkers { get; set; }

        public Worker Worker { get; set; }

        public List<SelectListItem> SelectListStores { get; set; }

        public Store Store { get; set; }

        public List<SelectListItem> SelectListHoldings { get; set; }

        public Holding Holding { get; set; }

        public List<SelectListItem> SelectListDepartments { get; set; }

        public Department Department { get; set; }


        public List<SelectListItem> SelectListPositions { get; set; }

        public Position Position { get; set; }
        public List<SelectListItem> SelectListPastPositions { get; set; }

        public PastPosition PastPosition { get; set; }

        public List<SelectListItem> SelectListCompanies { get; set; }

        public Company Company { get; set; }

        public List<SelectListItem> SelectListEmployees { get; set; }

        public Employee Employee { get; set; }
    }
}
