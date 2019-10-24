using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace PayrollApp.Models.Employment
{
    [Table("PastEmployments", Schema = "employment")]
    public class PastEmployment
    {
        public int Id { get; set; }

        
        
        [Required(ErrorMessage = "Şirkətin adı qeyd olunmalıdır.")]
        [Display(Name = "Şirkət")]
        [MinLength(2)]
        [StringLength(30, ErrorMessage = "Zəhmət olmasa Şirkətin adını uzunluğunu düzgün yazın.")]
        public string Company { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "smalldatetime")]
        [Required(ErrorMessage = "İşdən başlama tarixi qeyd olunmalıdır.")]
        [Display(Name = "İşə başlama tarixi")]
        public DateTime StartDate { get; set; }


        [DataType(DataType.Date)]
        [Column(TypeName = "smalldatetime")]
        [Required(ErrorMessage = "İşdən çıxma tarixi qeyd olunmalıdır.")]
        [Display(Name = "İşdən çıxma tarixi")]
        public DateTime EndDate { get; set; }

       
        [Required(ErrorMessage = "İşdən çıxma səbəbi qeyd olunmalıdır.")]
        [StringLength(250, ErrorMessage = "Zəhmət olmasa İşdən çxma səbəbinin uzunluğunu düzgün yazın.")]
        [Display(Name = "İşdən çıxma səbəbi")]
        public string TheReasonForFailure { get; set; }
        [Display(Name = "İşçi")]
        public Employee Employee { get; set; }
        
        public int EmployeeId { get; set; }
    }
}
