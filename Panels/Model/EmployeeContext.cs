using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panels.Model
{
    public class EmployeeContext : DbContext
    {
       public EmployeeContext(): base("name=con") { }
       public DbSet<Employee> EmpList { get; set; }
       public DbSet<Department> DepartmentList { get; set;}
    }
}
