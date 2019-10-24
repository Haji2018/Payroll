using PayrollApp.Models.Employment;
using PayrollApp.Models.Employment.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollApp.Models.DepartmentHead
{


    [Table("StoreBonuses", Schema = "departmentHead")]
    public class StoreBonus
    {



        public int Id { get; set; }
        [Required(ErrorMessage = "Bonusun miqdarı qeyd olunmalıdır.")]
        [Display(Name = "Bonus Miqdarı")]
        [StringLength(12, ErrorMessage = "Zəhmət olmasa Bonusun miqdarını  düzgün yazın.")]
        public string Amount { get; set; }



        [Display(Name = "Ay")]
        public Month Month { get; set; }



        public Store Store { get; set; }
        [Required(ErrorMessage = "İşçinin adı qeyd olunmalıdır.")]
        [Display(Name = "Magaza")]
        public int StoreId { get; set; }


        [DataType(DataType.Date)]
        [Column(TypeName = "smalldatetime")]
        [Display(Name = "Dəqiq Tarix")]
        public DateTime StoreBonusWritedDate { get; set; }
    }

}
