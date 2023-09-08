using BasicSalary.Data.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSalary.Entities.AppContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<EmployeeDetails> employeeDetails { get; set; }
        public DbSet<SalaryGenerator> salaryGenerators { get; set; }

        //public List<SalaryGenerator> GetEmployeeSalaries(int year,string month)
        //{
        //    return this.Set<SalaryGenerator>()
        //   .FromSqlRaw("EXEC GetEmployeeSalaries @Year, @Month",
        //       new SqlParameter("@Year", year),
        //       new SqlParameter("@Month", month))
        //   .ToList();
        //}
    }
}
