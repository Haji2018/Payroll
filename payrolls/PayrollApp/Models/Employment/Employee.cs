using Microsoft.AspNetCore.Http;
using PayrollApp.Models.Employment;
using PayrollApp.Models.PayrollSpecialist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PayrollApp.Models.Employment
{
    [Table("Employees", Schema = "employment")]
    public class Employee
    {
        public Employee()
        {
            PastEmployments = new HashSet<PastEmployment>();
            SalaryPayments = new HashSet<SalaryPayment>();
        }

        public int Id { get; set; }

        [MinLength(2)]
        
        [Required(ErrorMessage = " Ad qeyd olunmalıdır.")]
        [StringLength(50, ErrorMessage = "Zəhmət olmasa Adın uzunluğunu düzgün yazın.")]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [MinLength(2)]
        [Required(ErrorMessage = " Soyad qeyd olunmalıdır.")]
        [StringLength(50, ErrorMessage = "Zəhmət olmasa Soyadın uzunluğunu düzgün yazın.")]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }

        [MinLength(2)]
        
        [StringLength(50, ErrorMessage = "Zəhmət olmasa Ata adının uzunluğunu düzgün yazın.")]
        [Display(Name = "Ata adı")]
        public string Patronymic { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "smalldatetime")]
        [Required(ErrorMessage = " Doğum tarixi qeyd olunmalıdır.")]
        [Display(Name = "Doğum tarixi")]
        public DateTime Birthday { get; set; }

        [MinLength(2)]
     
        [StringLength(100, ErrorMessage = "Zəhmət olmasa Ünvanın  uzunluğunu düzgün yazın.")]
        [Display(Name = "Ünvan")]
        public string LivingPlace { get; set; }

        [MinLength(2)]
       
        [StringLength(100, ErrorMessage = "Zəhmət olmasa Qeydiyyatın  uzunluğunu düzgün yazın.")]
        [Display(Name = "Qeydiyyatı")]
        public string DistrictRegistration { get; set; }

        [MinLength(2)]
     
        [StringLength(100, ErrorMessage = "Zəhmət olmasa Vəsiqə nömrəsinin  uzunluğunu düzgün yazın.")]
        [Display(Name = "Seria:AZE")]
        public string IdentityCardNumber { get; set; }

       

        //[NotMapped]
        //public IFormFile IFormFile { get; set; }

        
      
        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Şəkil")]
        public string Image { get; set; }
        [Display(Name = "Cins")]
        public Gender Gender { get; set; }
        public int GenderId { get; set; }
        [Display(Name = "Ailə vəziyyəti")]
        public FamilyStatus FamilyStatus { get; set; }
        public int FamilyStatusId { get; set; }
        [Display(Name = "Təhsil")]
        public Education Education { get; set; }
        public int EducationId { get; set; }
        public ICollection<PastEmployment> PastEmployments { get; set; }

        public ICollection<SalaryPayment> SalaryPayments { get; set; }
    }
}
