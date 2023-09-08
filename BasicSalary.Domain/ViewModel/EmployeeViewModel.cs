using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSalary.Domain.ViewModel
{
    public class EmployeeViewModel
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string Branch { get; set; }
        public long MobileNumber { get; set; }
        public string Address { get; set; }
        public decimal BasicSalary { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public decimal Allowance { get; set; }
        public decimal PF { get; set; }
        public int WorkingDays { get; set; }
        public int LeaveDays { get; set; }
        public decimal TotalSalary { get; set; }
    }
}
