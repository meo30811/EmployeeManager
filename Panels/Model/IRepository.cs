using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panels.Model
{
    public interface IRepository
    {
      Employee GetEmployeeById(string Employee_Id);
      void AddEmployee(Employee employee);
      void DeleteEmployee(string Employee_Id);
      void UpdateEmployee(Employee employee);
      int AddDepartment(Department department);
      string GetDepartmentById(int id);
      List<Employee> GetAllEmployees();

    }
}
