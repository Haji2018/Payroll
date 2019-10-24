using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApp.Models.Employment
{
    [Table("Xitam", Schema = "employment")]
    public class Xitam
    {

        public int Id { get; set; }



        [DataType(DataType.Date)]
        [Column(TypeName = "smalldatetime")]
        [Display(Name = "BitirməTarixi")]
        public DateTime EndDate { get; set; }




        [Required]
        [Display(Name = "Ad Soyad")]
        public int WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
