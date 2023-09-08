using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSalary.Data.Model
{
    public class SalaryGenerator
    {
        [Key]
        public int SNo { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        [Required]
        public string Month { get; set; }

        [Required]
        public int Year { get; set; }
        [Required]
        public decimal Allowance { get; set; }
        public decimal PF { get; set; }
        [Required]
        public int WorkingDays { get; set; }
        [Required]
        public int LeaveDays { get; set; }


    }
}
