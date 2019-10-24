
using PayrollApp.Models.DepartmentHead;
using PayrollApp.Models.PayrollSpecialist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollApp.Models.Employment
{
    [Table("Workers", Schema = "employment")]
    public class Worker
    {
        public Worker()
        {
            WorkerBonuses = new HashSet<WorkerBonus>();
            Absents = new HashSet<Absent>();
            Vacations = new HashSet<Vacation>();
            Payments = new HashSet<Payment>();
            Xitams = new HashSet<Xitam>();
            WorkerPenalties = new HashSet<WorkerPenalty>();
        }
        public int Id { get; set; }
        [Display(Name = "Şirkət")]
        public Company Company { get; set; }
        [Display(Name = "Şirkət")]
        public int CompanyId { get; set; }
        [Display(Name = "Departament")]
        public Department Department { get; set; }

        public int DepartmentId { get; set; }
        [Display(Name = "Mağaza")]
        public Store Store { get; set; }


        public int? StoreId { get; set; }


        [Display(Name = "Vəzifə")]
        public Position Position { get; set; }

        public int PositionId { get; set; }
        [Display(Name = "Keçmiş Vəzifə")]
        public PastPosition PastPosition { get; set; }

        public int? PastPositionId { get; set; }
        [Display(Name = "İşçi")]
        public Employee Employee { get; set; }

        public int EmployeeId { get; set; }



        [DataType(DataType.Date)]
        [Column(TypeName = "smalldatetime")]
        [Required(ErrorMessage = "İşə başlama tarixi qeyd olunmalıdır.")]
        [Display(Name = "BaşlamaTarixi")]
        public DateTime StartDate { get; set; }

   
      


        public ICollection<Xitam> Xitams { get; set; }
        public ICollection<WorkerBonus> WorkerBonuses { get; set; }
        public ICollection<Payment> Payments { get; set; }

        public ICollection<Vacation> Vacations { get; set; }
        public ICollection<WorkerPenalty> WorkerPenalties { get; set; }
        public ICollection<Absent> Absents { get; set; }


    }
}
