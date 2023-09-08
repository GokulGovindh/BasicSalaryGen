using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSalary.Domain.ViewModel
{
    public class GroupedEmployeeViewModel
    {
        public string Designation { get; set; }
        public decimal TotalBasicSalary { get; set; }
        public IEnumerable<EmployeeViewModel> Employees { get; set; }
    }
}
