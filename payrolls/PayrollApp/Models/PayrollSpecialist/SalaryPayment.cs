using PayrollApp.Models.Employment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApp.Models.PayrollSpecialist
{
    [Table("SalaryPayments", Schema = "payrollSpecialist")]
    public class SalaryPayment
    {

       
       
            public int Id { get; set; }


            public  Employee Employee { get; set; }
            public int EmployeeId { get; set; }

          
            public  Position Position { get; set; }

            public int PositionId { get; set; }

            public string WorkerBonus { get; set; }

       
        [Display(Name = "Tarix")]
        [DataType(DataType.Date)]
        [Column(TypeName = "smalldatetime")]
            public DateTime PaymentDate { get; set; }
            public string WorkerPenalty { get; set; }

            public string StoreBonus { get; set; }

            public string AttandenceCount { get; set; }

            public string VacationDay { get; set; }

            public string PaymentAmount { get; set; }
        }
    }

