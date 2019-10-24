using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollApp.Areas.PayrollSpecialist.ViewModels;
using PayrollApp.Models.DAL;
using PayrollApp.Models.PayrollSpecialist;

namespace PayrollApp.Areas.PayrollSpecialist.Controllers
{
    [Area("PayrollSpecialist")]
    [Authorize(Roles = "Specialist")]
    public class PaymentController : Controller
    {

        public PayrollDbContext _payrollDb { get; }

        public PaymentController(PayrollDbContext dbContext)
        {
            _payrollDb = dbContext;

        }
        [HttpGet]
        public IActionResult CreatePayment()
        {

            return View();



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePayment(Payment payment)
        {
            if (ModelState.IsValid)
            {

                Payment p = payment;
                await _payrollDb.Payments.AddAsync(p);
                await _payrollDb.SaveChangesAsync();
                return RedirectToAction(nameof(ListPayment));
            }
            else
            {
                return View();
            }



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPayment(int id, Payment payment)
        {
            Payment models = await _payrollDb.Payments.FindAsync(id);

            if (ModelState.IsValid)
            {
                if (models != null)
                {

                    models.PaymentDate = payment.PaymentDate;
                    models.WorkerId = payment.WorkerId;

                    await _payrollDb.SaveChangesAsync();
                    return RedirectToAction(nameof(ListPayment));

                }

                else
                    return Redirect("~/Account/Error");
            }
            else
            {
                return View();
            }





        }
        [HttpGet]
        public async Task<IActionResult> EditPayment(int id)
        {
         

            var workers = await _payrollDb.Workers.Include(c => c.Employee).ToListAsync();
            ViewBag.Workers = workers;
        
            var models = await _payrollDb.Payments.FindAsync(id);

            return View(models);

        }



        //public async Task<IActionResult> ListPayment()
        //{

        //    var payment = await _payrollDb.Payments.Include(x => x.Worker).ThenInclude(a => a.Employee).OrderByDescending(x => x.Id).ToListAsync();

        //    return
        //        View(payment);

        //}


        public IEnumerable<Payment> GetSearchResult(string searchString)
        {
            List<Payment> data = new List<Payment>();
            try
            {
                data = GetAllCompany().ToList();
                return data.Where(x => x.Worker.Employee.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<Payment> GetAllCompany()
        {
            try
            {


                return _payrollDb.Payments.Include(c => c.Worker).ThenInclude(a => a.Employee).
             OrderByDescending(x => x.Id).Take(4);

            }
            catch
            {
                throw;
            }
        }
        public IActionResult ListPayment(string searchString)
        {
            ViewBag.TotalCount = _payrollDb.Payments.Count();
            var payment1 = _payrollDb.Payments.ToList();
            ViewBag.Payments = payment1;
            List<Payment> payments = new List<Payment>();
            payments = GetAllCompany().ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                payments = GetSearchResult(searchString).ToList();
            }

            return View(payments);
        }


        public IActionResult LoadMore(int skip)
        {
            var model = _payrollDb.Payments.Include(c => c.Worker).ThenInclude(a => a.Employee).OrderByDescending(x => x.Id).Skip(skip).Take(4);

            return PartialView("LoadMorePayment", model);

        }

        public IActionResult LoadMoreResultSalary(int skip)
        {
            var model = _payrollDb.SalaryPayments.Include(c => c.Employee).OrderByDescending(x => x.Id).Skip(skip).Take(4);

            return PartialView("LoadMoreResult", model);

        }




        public IEnumerable<SalaryPayment> GetSearchSalaryResult(string searchString)
        {
            List<SalaryPayment> data = new List<SalaryPayment>();
            try
            {
                data = GetAllSalaryResult().ToList();
                return data.Where(x => x.Employee.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<SalaryPayment> GetAllSalaryResult()
        {
            try
            {


                return _payrollDb.SalaryPayments.Include(c => c.Employee).Include(x=>x.Position).
             OrderByDescending(x => x.Id).Take(4);

            }
            catch
            {
                throw;
            }
        }
        public IActionResult ListResult(string searchString)
        {
            ViewBag.TotalCount = _payrollDb.SalaryPayments.Count();
            var result = _payrollDb.SalaryPayments.ToList();
            ViewBag.SalaryPayments = result;
            List<SalaryPayment> result1 = new List<SalaryPayment>();
            result1 = GetAllSalaryResult().ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                result1 = GetSearchSalaryResult(searchString).ToList();
            }

            return View(result1);
        }






        #region dəyişənlər
        public decimal vacationSalary;
        public decimal vacationSalary1;
        public decimal vacationDay;
        public decimal totalDayWork;
        public DateTime data3;
        public DateTime data4;
        public decimal workerbonus3;
        public decimal workerpenalty3;
        public decimal storeBonus3;
        public decimal totalDayWorkChangePosition;
        public decimal salaryOneDaySalary;
        public decimal salarydata2;
        public decimal absentDaySalary;
        public decimal resultAbsentCount;
        public decimal resultVacationCount;
        #endregion

        public async Task<IActionResult> GivePayment(int id)
        {
            #region Data
            var data = await _payrollDb.Workers.Include(x => x.Employee).Include(x => x.Company)
              .Include(x => x.Department)

                .Include(x => x.Position)
                  .Include(x => x.PastPosition)
                  .Include(x => x.Store)
                     .Where(x => x.Id == id).FirstOrDefaultAsync();
            #endregion

            #region Vəzifəsini dəyişibsə
            var workerXitam = await _payrollDb.Xitams.Include(x => x.Worker).ToListAsync();
            if (workerXitam.Capacity == 4)
            {
                foreach (var item in workerXitam)
                {
                    if (item.WorkerId == id)
                    {
                        if (item.EndDate.Day > data.StartDate.Day)
                            totalDayWorkChangePosition = Math.Abs(item.EndDate.Day - data.StartDate.Day) + 1;
                        salaryOneDaySalary = (data.PastPosition.PositionSalary / 30);
                        break;
                    }
                }
            }
            #endregion

            #region Multiple Salaary Calculate
            var salaryData = await _payrollDb.SalaryPayments.Include(x => x.Position).Where(x => x.EmployeeId == data.EmployeeId).ToListAsync();
            #endregion

            #region Hesabla datanın içindəki günləri və ayları
            if (salaryData != null)
            {
                foreach (var item in salaryData)
                {

                    salarydata2 = item.PaymentDate.Day;
                }   
                var data10 = await _payrollDb.Payments.Include(x => x.Worker).Where(x => x.WorkerId == id).ToListAsync();
                if (data10 != null)
                {
                    foreach (var item in data10)
                    {
                        data3 = item.PaymentDate;
                    }
                }  
                    
            #endregion

            #region İşçi neçə gün işləyib
            if (data3.Month > data.StartDate.Month)
                {
                    totalDayWork = (salarydata2 - totalDayWorkChangePosition);
                }
            }
            #endregion

            #region Hesabla datanın içindəki günləri və ayları
            if (salaryData.Count ==0)
            {              
                var data1 = await _payrollDb.Payments.Include(x => x.Worker).Where(x => x.WorkerId == id).ToListAsync();
                if (data1 != null)
                {
                    foreach (var item in data1)
                    {
                        data3 = item.PaymentDate;
                    }
                }
           
            #endregion

            #region İşçi neçə gün işləyib
            if (data3.Month > data.StartDate.Month)
                {
                    totalDayWork = Math.Abs(((31 - data.StartDate.Day) + data3.Day) - totalDayWorkChangePosition);
                }
                if (data3.Month == data.StartDate.Month)
                {
                    totalDayWork = ((1 + data3.Day - data.StartDate.Day) - totalDayWorkChangePosition);
                }
                else
                    ModelState.AddModelError("", "Maaw alma ayi maaw hesablanma ayindan kicik ola bilmez");
                #endregion
            }
            #region Bonus, Cərimə, Mağaza, Bonusu, Qayıb hesablanması
            var workerBonus = await _payrollDb.WorkerBonuses.Include(x => x.Worker).ToListAsync();
            if (workerBonus != null )
            {
                foreach (var item in workerBonus)
                {
                    if (item.WorkerId == id && data3.Month == item.BonusWritedDate.Month )
                    {                      
                            workerbonus3 = Convert.ToDecimal(item.Amount);
                            break;                                       
                    }
                }
            }
            var workerPenalty = await _payrollDb.WorkerPenalties.Include(x => x.Worker).ToListAsync();
            if (workerPenalty != null)
            {
                foreach (var item in workerPenalty)
                {
                    if (item.WorkerId == id && data3.Month == item.PenaltyWritedDate.Month )
                    {   
                            workerpenalty3 = Convert.ToDecimal(item.Amount);
                            break;               
                    }
                }
            }
            var storeBonus = await _payrollDb.StoreBonuses.Include(x => x.Store).ToListAsync();
            if (workerPenalty != null)
            {
                foreach (var item in storeBonus)
                {

                    if (item.StoreId == data.StoreId && data3.Month == item.StoreBonusWritedDate.Month)
                    {
                        storeBonus3 = Convert.ToDecimal(item.Amount);
                        break;
                    }
                }
            }
            #endregion

            #region Bir gündə alınan maaş
            var salaryOneDaySalaryNewPosition = (data.Position.PositionSalary / 30);
            #endregion

            #region Qayıb
            var workerAbsent = await _payrollDb.Absents.Where(x => x.WorkerId == id && x.Attandence == 0).ToListAsync();
            if (workerAbsent !=null) {
                foreach (var item in workerAbsent)
                {
                    if (data3.Month == item.AbsentDate.Month)
                    {
                        var result = (item.Attandence == 0);
                        resultAbsentCount += Convert.ToDecimal(result);
                    }
                }
                if (resultAbsentCount > 2)
                {
                    absentDaySalary = 2 * (resultAbsentCount * salaryOneDaySalaryNewPosition);
                }
                else
                    absentDaySalary = resultAbsentCount * salaryOneDaySalaryNewPosition;
            }
            #endregion

            #region   Məzuniyyətin hesablanması
            var vacation = await _payrollDb.Vacations.Where(x => x.WorkerId == id && x.WorkerVacation == 0 || x.WorkerVacation != 0).ToListAsync();
            if (vacation != null)
            {
                foreach (var item in vacation)
                {
                    if (item.WorkerId == id && data3.Month == item.StartDate.Month && item.WorkerVacation.ToString() == "Əmək" || item.WorkerVacation.ToString() == "Sosial")
                    {
                        if (item.EndDate.Month > item.StartDate.Month)
                        {
                            vacationDay = (31 - item.StartDate.Day + item.EndDate.Day);
                            vacationSalary = Convert.ToDecimal((vacationDay * salaryOneDaySalaryNewPosition) / 2);
                        }
                        if (item.EndDate.Month == item.StartDate.Month)
                        {
                            vacationDay = item.EndDate.Day - item.StartDate.Day;
                            vacationSalary = Convert.ToDecimal((vacationDay * salaryOneDaySalaryNewPosition) / 2);
                        }
                    }
                }
            }
            #endregion

            var TotalSalary = (salaryOneDaySalary * totalDayWorkChangePosition) - absentDaySalary - vacationSalary - vacationSalary1;
            var TotalSalaryNewSalary = (salaryOneDaySalaryNewPosition * (totalDayWork));
            var TolalSalaryAll = (TotalSalary + TotalSalaryNewSalary + Convert.ToDecimal(workerbonus3) - Convert.ToDecimal(workerpenalty3) + Convert.ToDecimal(storeBonus3));

            SalaryPayment workerSalary = new SalaryPayment()
            {
                EmployeeId = data.EmployeeId,
                Employee = data.Employee,
                PositionId = data.PositionId,
                Position = data.Position,
                WorkerBonus = workerbonus3.ToString(),
                WorkerPenalty = workerpenalty3.ToString(),
                StoreBonus = storeBonus3.ToString(),
                AttandenceCount = resultAbsentCount.ToString(),
                VacationDay = vacationDay.ToString(),
                PaymentAmount = TolalSalaryAll.ToString(),
                PaymentDate = data3,
            };
            if (workerSalary != null)
            {
                
                await _payrollDb.SalaryPayments.AddAsync(workerSalary);
                await _payrollDb.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ListResult));
        }












































        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var data = await _payrollDb.Payments.FindAsync(id);

                if (data != null)
                {
                    return Json(new { companyDb = data, message = 200 });
                }
            }

            return Json(new { message = 400 });
        }
        [HttpPost]

        public async Task<IActionResult> DeletePost(int? id)
        {
            var data = await _payrollDb.Payments.FindAsync(id);

            if (data != null)
            {
                _payrollDb.Payments.Remove(data);

                await _payrollDb.SaveChangesAsync();
            }

            return Json(new { companyDb = data, message = 200 });
        }



        [HttpGet]
        public async Task<IActionResult> DeleteSalary(int? id)
        {
            if (id != null)
            {
                var data = await _payrollDb.SalaryPayments.FindAsync(id);

                if (data != null)
                {
                    return Json(new { companyDb = data, message = 200 });
                }
            }

            return Json(new { message = 400 });
        }
        [HttpPost]

        public async Task<IActionResult> DeletePostSalary(int? id)
        {
            var data = await _payrollDb.SalaryPayments.FindAsync(id);

            if (data != null)
            {
                _payrollDb.SalaryPayments.Remove(data);

                await _payrollDb.SaveChangesAsync();
            }

            return Json(new { companyDb = data, message = 200 });
        }
    }
}