using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApp.Models.Library
{
    [Table("Departaments", Schema = "library")]
    public class LibDepartament
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string DepartmentName { get; set; }

    }
}
