using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApp.Models.Employment
{
    [Table("FamilyStatus", Schema = "common")]
    public class FamilyStatus
    {
        public int Id { get; set; }
        public FamilyStatus()
        {
            Employees = new HashSet<Employee>();
        }

        [Column(TypeName = "nvarchar(5)")]
        public string Status { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
