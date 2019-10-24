using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApp.Areas.PayrollAdmin.ViewModels
{
    public class ListUserViewModel
    {
        public IList<PayrollApp.Models.ForIdentity.ApplicationUser> users { get; set; }
        public IList<string> roles { get; set; }
    }
}
