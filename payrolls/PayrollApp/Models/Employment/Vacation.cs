using PayrollApp.Models.Employment.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApp.Models.Employment
{
    [Table("Vacations", Schema = "employment")]
    public class Vacation
    {
        public int Id { get; set; }





        [Display(Name = " Məzuniyyət Növləri")]
        public WorkerVacation WorkerVacation { get; set; }

        [Required(ErrorMessage = "Tarixi daxil edin")]
        [Display(Name = " Başlama Tarixi")]
        [DataType(DataType.Date)]
        [Column(TypeName = "smalldatetime")]
        public DateTime StartDate { get; set; }


        [Required(ErrorMessage = "Tarixi daxil edin")]
        [Display(Name = "Bitmə Tarixi")]
        [DataType(DataType.Date)]
        [Column(TypeName = "smalldatetime")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Ad Soyad")]
        public int WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
