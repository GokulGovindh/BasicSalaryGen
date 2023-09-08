using BasicSalary.Domain.ViewModel;
using BasicSalary.Entities.AppContext;
using Microsoft.AspNetCore.Mvc;

namespace BasicSalary.Controllers
{
    public class SalaryGenController : Controller
    {
        private static ApplicationDbContext _dbContext;

        public SalaryGenController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pay()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Pay(string employeeId,string month,int year)
        {
            var salaryInfo = _dbContext.salaryGenerators
            .Join(
                _dbContext.employeeDetails,
                salary => salary.EmployeeId,
                employee => employee.EmployeeId,
                (salary, employee) => new { salary, employee }
            )
            .Where(joined => joined.salary.EmployeeId == employeeId && joined.salary.Month == month && joined.salary.Year == year)
            .Select(joined => new EmployeeViewModel
            {
                EmployeeId = joined.employee.EmployeeId,
                EmployeeName = joined.employee.EmployeeName,
                Designation = joined.employee.Designation,
                BasicSalary = joined.employee.BasicSalary,
                Allowance = joined.salary.Allowance,
                PF = joined.salary.PF,
                TotalSalary = joined.employee.BasicSalary + joined.salary.PF + joined.salary.Allowance,
                WorkingDays = joined.salary.WorkingDays,
                LeaveDays = joined.salary.LeaveDays
            });

            return View("PaySlipDetails", salaryInfo.ToList());

        }

        public IActionResult Employee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Employee(string employeeId)
        {
            var employeeDetails = _dbContext.employeeDetails
           .Where(employee => employee.EmployeeId == employeeId)
           .Select(employee => new EmployeeViewModel
           {
               EmployeeId = employee.EmployeeId,
               EmployeeName = employee.EmployeeName,
               Designation = employee.Designation,
               Branch = employee.Branch,
               MobileNumber = employee.MobileNumber,
               Address = employee.Address,
               BasicSalary = employee.BasicSalary
           });

            return View("EmployeeDetails", employeeDetails.ToList());

        }

        public IActionResult Record()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Record(string employeeId, int year)
        {
           var salaryInfo = _dbContext.salaryGenerators
            .Join(
                _dbContext.employeeDetails,
                salary => salary.EmployeeId,
                employee => employee.EmployeeId,
                (salary, employee) => new { salary, employee }
            )
            .Where(joined => joined.salary.EmployeeId == employeeId && joined.salary.Year == year)
            .Select(joined => new EmployeeViewModel
            {
                EmployeeId = joined.employee.EmployeeId,
                Month = joined.salary.Month,
                BasicSalary = joined.employee.BasicSalary,
                Allowance = joined.salary.Allowance,
                PF = joined.salary.PF,
                TotalSalary = joined.employee.BasicSalary + joined.salary.PF + joined.salary.Allowance,
                WorkingDays = joined.salary.WorkingDays,
                LeaveDays = joined.salary.LeaveDays
            });

            return View("RecordDetails", salaryInfo.ToList());
        }

        public IActionResult ShowAllEmployee()
        {
            var employeeDetails = _dbContext.employeeDetails
            .OrderBy(employee => employee.EmployeeName) // Sort by EmployeeName in ascending order
            .Select(employee => new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                Designation = employee.Designation,
                Branch = employee.Branch,
                MobileNumber = employee.MobileNumber,
                Address = employee.Address,
                BasicSalary = employee.BasicSalary
            });

            return View(employeeDetails.ToList());
        }

        public IActionResult GroupEmployeesByDesignation()
        {
            var groupedEmployees = _dbContext.employeeDetails
                .Join(
                    _dbContext.salaryGenerators,
                    employee => employee.EmployeeId,
                    salary => salary.EmployeeId,
                    (employee, salary) => new { Employee = employee, Salary = salary }
                )
                .GroupBy(joined => joined.Employee.Designation)
                .Select(group => new GroupedEmployeeViewModel
                {
                    Designation = group.Key,
                    TotalBasicSalary = group.Sum(joined => joined.Employee.BasicSalary),
                    Employees = group.Select(joined => new EmployeeViewModel
                    {
                        EmployeeId = joined.Employee.EmployeeId,
                        EmployeeName = joined.Employee.EmployeeName,
                        Branch = joined.Employee.Branch,
                        MobileNumber = joined.Employee.MobileNumber,

                    }).ToList()
                })
                .ToList();

            return View(groupedEmployees);
        }

        public IActionResult GroupEmployeesByDesignationWithFilter(decimal minTotalBasicSalary)
        {
            ViewBag.MinTotalBasicSalary = minTotalBasicSalary;

            var groupedEmployees = _dbContext.employeeDetails
                .Join(
                    _dbContext.salaryGenerators,
                    employee => employee.EmployeeId,
                    salary => salary.EmployeeId,
                    (employee, salary) => new { Employee = employee, Salary = salary }
                )
                .GroupBy(joined => joined.Employee.Designation)
                .Select(group => new GroupedEmployeeViewModel
                {
                    Designation = group.Key,
                    TotalBasicSalary = group.Sum(joined => joined.Employee.BasicSalary),
                    Employees = group.Select(joined => new EmployeeViewModel
                    {
                        EmployeeId = joined.Employee.EmployeeId,
                        EmployeeName = joined.Employee.EmployeeName,
                        Branch = joined.Employee.Branch,
                        MobileNumber = joined.Employee.MobileNumber,
                    }).ToList()
                })
                .ToList();

            return View(groupedEmployees);
        }

        //public IActionResult EnterYourMonth()
        //{
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult GetSalaries(int year,string month)
        //{
        //    var salaries = _dbContext.GetEmployeeSalaries(year, month);
        //    return View(salaries);
        //}
        //public IActionResult DisplayEmployeeIds()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult DisplayEmployeeIds(int id)
        //{
        //    var employeeIds = _dbContext.salaryGenerators
        //        .Select(salary => salary.EmployeeId)
        //        .Distinct()
        //        .ToList();

        //    ViewBag.EmployeeIds = employeeIds;

        //    return View("DisplaySalaryDetails");
        //}



        //public IActionResult GroupEmployeesByDesignationWithFilter(decimal minTotalBasicSalary)
        //{
        //    var groupedEmployees = _dbContext.employeeDetails
        //        .Join(
        //            _dbContext.salaryGenerators,
        //            employee => employee.EmployeeId,
        //            salary => salary.EmployeeId,
        //            (employee, salary) => new { Employee = employee, Salary = salary }
        //        )
        //        .GroupBy(joined => joined.Employee.Designation)
        //        .Select(group => new GroupedEmployeeViewModel
        //        {
        //            Designation = group.Key,
        //            TotalBasicSalary = group.Sum(joined => joined.Employee.BasicSalary),
        //            Employees = group.Select(joined => new EmployeeViewModel
        //            {
        //                EmployeeId = joined.Employee.EmployeeId,
        //                EmployeeName = joined.Employee.EmployeeName,
        //                Branch = joined.Employee.Branch,
        //                MobileNumber = joined.Employee.MobileNumber,
        //            }).ToList()
        //        })
        //        .Where(group => group.TotalBasicSalary >= minTotalBasicSalary) // Apply filtering here
        //        .ToList();

        //    return View(groupedEmployees);
        //}



    }

}
