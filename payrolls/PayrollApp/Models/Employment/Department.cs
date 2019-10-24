using PayrollApp.Models.Library;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollApp.Models.Employment
{
    [Table("Departments",Schema = "employment")]
    public class Department
    {
        public Department()
        {
            Workers = new HashSet<Worker>();
            Stores = new HashSet<Store>();
          

        }

        public int Id { get; set; }


        [Required(ErrorMessage = "Departament adı qeyd olunmalıdır.")]
        [StringLength(50, ErrorMessage = "Zəhmət olmasa Departamentin adının uzunluğunu düzgün yazın.")]
        [Display(Name = "Departament")]
        public string DepartmentName { get; set; }
        public LibDepartament LibDepartament { get; set; }
        public int? LibDepartamentId { get; set; }



        [Required(ErrorMessage = "Departamentin əlaqə nömrəsi qeyd olunmalıdır.")]
        [Display(Name = "Əlaqə nömrəsi")]
        [StringLength(12, ErrorMessage = "Zəhmət olmasa əlaqə nömrəsinin uzunluğunu düzgün yazın.")]
        public string Phone { get; set; }
        [Display(Name = "Şirkət")]
        public Company Company { get; set; }
      
        public int CompanyId { get; set; }
        public ICollection<Worker> Workers { get; set; }
        public ICollection<Store> Stores { get; set; }

       

    }
}
