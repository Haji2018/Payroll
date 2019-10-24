using PayrollApp.Models.DepartmentHead;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PayrollApp.Models.Employment
{
    [Table("Stories", Schema = "employment")]
    public class Store
    {
        public Store()
        {
            Workers = new HashSet<Worker>();
            StoreBonuses = new HashSet<StoreBonus>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Mağazanın adı  qeyd olunmalıdır.")]
        [StringLength(30, ErrorMessage = "Zəhmət olmasa Mağazanın adının uzunluğunu düzgün yazın.")]
        [Display(Name = "Mağaza")]

        public string StoreName { get; set; }

       
       
        [Required(ErrorMessage = "Mağazanın ünvanı  qeyd olunmalıdır.")]
        [StringLength(30, ErrorMessage = "Zəhmət olmasa Mağazaını ünvanının uzunluğunu düzgün yazın.")]
        [Display(Name = "Ünvan")]
        public string Address { get; set; }




        [Required(ErrorMessage = "Mağazanın əlaqə nömrəsi qeyd olunmalıdır.")]
        [Display(Name = "Əlaqə nömrəsi")]
        [StringLength(12, ErrorMessage = "Zəhmət olmasa əlaqə nömrəsinin uzunluğunu düzgün yazın.")]
        public string Phone { get; set; }



        [Display(Name = "Departament")]
        public Department Department { get; set; }

        public int DepartmentId { get; set; }
        public ICollection<Worker> Workers { get; set; }
        public ICollection<StoreBonus> StoreBonuses { get; set; }
    }
}
