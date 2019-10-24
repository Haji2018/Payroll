using PayrollApp.Models.PayrollSpecialist;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollApp.Models.Employment
{
    [Table("Positions", Schema = "employment")]
    public class Position
    {
        public Position()
        {
            Workers = new HashSet<Worker>();
            SalaryPayments = new HashSet<SalaryPayment>();
        }

        public int Id { get; set; }


        [Required(ErrorMessage = "Pozisiyanın adı tələb olunandır")]
        [StringLength(30, ErrorMessage = "Zəhmət olmasa Pozisiyanın adının uzunluğunu düzgün yazın.")]
        [Display(Name = "Vəzifənin adı")]
        public string PositionName { get; set; }

        [Required(ErrorMessage = "Pozisiyanın maaşı tələb olunandır")]
        [Column(TypeName = "nvarchar(30)")]
        [Display(Name = "Maaş")]
        public int PositionSalary { get; set; }


        [Display(Name = "Departament")]
        public Department Department { get; set; }

        
        public int DepartmentId { get; set; }

        [Display(Name = "Şirkət")]
        public Company Company { get; set; }

       
        public int CompanyId { get; set; }

        public ICollection<Worker> Workers { get; set; }

        public ICollection<SalaryPayment> SalaryPayments { get; set; }
    }
}
