
using PayrollApp.Models.Employment;
using PayrollApp.Models.Head;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollApp.Models.Employment
{
    [Table("Companies",Schema = "employment")]
    public class Company
    {
        public Company()
        {
            Departments = new HashSet<Department>();
           
            Workers = new HashSet<Worker>();
           
        }

        public int Id { get; set; }


       

        [Required(ErrorMessage = "Şirkət adı qeyd olunmalıdır.")]
        [StringLength(50, ErrorMessage = "Zəhmət olmasa Şirkətin adının uzunluğunu düzgün yazın.")]
        [Display(Name = "Şirkət")]

        public string CompanyName { get; set; }




        [Required(ErrorMessage = "Şirkətin ünvanı  qeyd olunmalıdır.")]
        [Display(Name = "Ünvan")]
        [StringLength(100, ErrorMessage = "Zəhmət olmasa Ünvanın uzunluğunu düzgün yazın.")]
        public string Address { get; set; }



        [Required(ErrorMessage = "Şirkətin əlaqə nömrəsi qeyd olunmalıdır.")]
        [Display(Name = "Əlaqə nömrəsi")]
        [StringLength(12, ErrorMessage = "Zəhmət olmasa əlaqə nömrəsinin uzunluğunu düzgün yazın.")]
        public string Phone { get; set; }



        [Required(ErrorMessage = "Şirkətin haqqında  qeyd olunmalıdır.")]
        [MaxLength(600)]
        [Display(Name = "Haqqımızda")]

        public string About { get; set; }

        
        [Display(Name = "Holding")]
        public Holding Holding { get; set; }
        
        public int HoldingId { get; set; }
        public ICollection<Worker> Workers { get; set; }
        public ICollection<Department> Departments { get; set; }





    }
}
