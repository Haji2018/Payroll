using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApp.Models.Employment
{
    [Table("Educations", Schema = "common")]
    public class Education
    {
        public Education()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string EducationType { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
