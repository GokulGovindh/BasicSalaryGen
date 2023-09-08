using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSalary.Data.Model
{
    public class EmployeeDetails
    {
        [Key]
        public string EmployeeId { get; set; }

        [Required,MinLength(3)]
        public string EmployeeName { get; set; }
        public string? Branch { get; set; }

        [Required]
        public string Designation { get; set; }

        [StringLength(10),Required]
        public long MobileNumber { get; set; }
        public string? Address { get; set; }

        [Required]
        public decimal BasicSalary { get; set; }
    }
}
