using PayrollApp.Models.Employment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApp.Models.PayrollSpecialist
{
    [Table("Payments", Schema = "payrollSpecialist")]
    public class Payment
    {
        public int Id { get; set; }



        [DataType(DataType.Date)]
        [Column(TypeName = "smalldatetime")]
        [Required(ErrorMessage = "İşə Maaş alma tarixi qeyd olunmalıdır.")]
        [Display(Name = "Maaş Alma Tarixi")]
        public DateTime PaymentDate { get; set; }

        public virtual Worker Worker { get; set; }
        [Display(Name = "İşçi Adı")]
        public int WorkerId { get; set; }
    }
}
