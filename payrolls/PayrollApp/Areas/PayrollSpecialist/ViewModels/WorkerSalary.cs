using PayrollApp.Models.Employment;
using PayrollApp.Models.PayrollSpecialist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApp.Areas.PayrollSpecialist.ViewModels
{
    public class WorkerSalary
    {

        public int Id { get; set; }

       
        public Employee   Employee { get; set; }
         public int EmployeeId { get; set; }


        public Position Position { get; set; }

        public int PositionId { get; set; }

        public string WorkerBonus { get; set; }

        public string PaymentDateTime { get; set; }
        public string WorkerPenalty { get; set; }

        public string StoreBonus { get; set; }

        public string AttandenceCount { get; set; }

        public string VacationDay { get; set; }

        public string PaymentAmount { get; set; }
    }
}
