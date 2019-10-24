using PayrollApp.Models.Employment.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApp.Models.Employment
{
    [Table("Absents", Schema = "employment")]
    public class Absent
    {
        public int Id { get; set; }

      
        [Display(Name = "Qayıb Cedveli")]
        public Attandence Attandence { get; set; }

        [Required(ErrorMessage = "Səbəb Qeyd olunmalıdır.")]
        [Display(Name = "Qeyd")]
        [StringLength(500, ErrorMessage = "Zəhmət olmasa qeydin uzunluğunu düzgün yazın.")] 
        public string Reason { get; set; }

        [Required(ErrorMessage = "Tarixi daxil edin")]
        [Display(Name = "Tarix")]
        [DataType(DataType.Date)]
        [Column(TypeName = "smalldatetime")]
        public DateTime AbsentDate { get; set; }

      
        [Required]
        [Display(Name = "Ad Soyad")]
        public int WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
