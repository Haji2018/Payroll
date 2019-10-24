using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApp.Models.Employment
{
    [Table("Genders", Schema = "common")]
    public class Gender
    {
    
        public Gender()
        {
            Employees = new HashSet<Employee>();
        }
        public int Id { get; set; }


        [Column(TypeName = "nvarchar(5)")]
        public string PersonGender { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
