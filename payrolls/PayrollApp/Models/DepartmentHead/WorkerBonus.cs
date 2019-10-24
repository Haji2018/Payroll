
using PayrollApp.Models.Employment;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PayrollApp.Models.DepartmentHead
{
    [Table("WorkerBonuses", Schema ="departmentHead")]
    public class WorkerBonus
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bonusun miqdarı qeyd olunmalıdır.")]
        [Display(Name = " İşçi Bonusu")]
        [StringLength(12, ErrorMessage = "Zəhmət olmasa İşçinin bonus miqdarını düzgün yazın.")]
      
        public string Amount { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "smalldatetime")]
      
        [Display(Name = "Ay")]
        public DateTime BonusWritedDate { get; set; }




  
        public Worker Worker { get; set; }
        [Required(ErrorMessage = "İşçi bonusu qeyd olunmalıdır.")]
        [Display(Name = "İşçi")]
        public int WorkerId { get; set; }
    }
}
