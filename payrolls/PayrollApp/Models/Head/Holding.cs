using PayrollApp.Models.Employment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PayrollApp.Models.Head
{
    [Table("Holdings",Schema ="head")]
    public class Holding
    {
        public Holding()
        {
            Companies = new HashSet<Company>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Holding adı qeyd olunmalıdır.")]
        [StringLength(50, ErrorMessage = "Zəhmət olmasa Holdingin adının uzunluğunu düzgün yazın.")]
        [Display(Name = "Holding")]
        
        public string HoldingName { get; set; }




        [Required(ErrorMessage = "Holdingin ünvanı  qeyd olunmalıdır.")]
        [Display(Name = "Ünvan")]
       
        public string Address { get; set; }



        [Required(ErrorMessage = "Holdingin əlaqə nömrəsi qeyd olunmalıdır.")]
        [Display(Name = "Əlaqə nömrəsi")]
        
        public string Phone { get; set; }



        [Required(ErrorMessage = "Holdingin haqqında  qeyd olunmalıdır.")]
        [MaxLength(600)]
        [Display(Name = "Haqqımızda")]

        public string About { get; set; }

        public ICollection<Company> Companies { get; set; }
    }
}
