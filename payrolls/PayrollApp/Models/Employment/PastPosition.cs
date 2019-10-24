using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApp.Models.Employment
{
    [Table("PastPositions", Schema = "employment")]
    public class PastPosition
    {
        public PastPosition()
        {
            Workers = new HashSet<Worker>();
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
    }
}
