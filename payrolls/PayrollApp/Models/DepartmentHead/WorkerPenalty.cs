
using PayrollApp.Models.Employment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PayrollApp.Models.DepartmentHead
{
    [Table("WorkerPenalties", Schema = "departmentHead")]
    public class WorkerPenalty
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Cərimənon miqdarı qeyd olunmalıdır.")]
        [Display(Name = " İşçi Cəriməsi")]
        [StringLength(12, ErrorMessage = "Zəhmət olmasa İşçinin cərimə miqdarını düzgün yazın.")]
       
        public string Amount { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "smalldatetime")]
     
        [Display(Name = "Ay")]
        public DateTime PenaltyWritedDate { get; set; }




        public Worker Worker { get; set; }

        [Required(ErrorMessage = "İşçinin adı qeyd olunmalıdır.")]
        [Display(Name = "İşçi")]
        public int WorkerId { get; set; }
    }
}
