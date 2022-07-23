using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Panels.Model;
using System.Data.Entity.Validation;
using System.Windows.Forms;

namespace Panels.ViewModels
{
    public class EmployeeViewModel : IRepository
    {
        private static EmployeeViewModel instance = null;

        /// <summary>
        /// instanciate this object ones
        /// </summary>
        /// <returns></returns>
        public static EmployeeViewModel getInstance()
        {
            if (instance == null)
            {
                instance = new EmployeeViewModel();
            }
            return instance;
        }
        /// <summary>
        /// add a single Employee in the Database
        /// </summary>
        /// <param name="employee"></param>
        public void AddEmployee(Employee employee)
        {
                using (EmployeeContext db = new EmployeeContext())
                {
                    var emp = db.EmpList.FirstOrDefault(em => em.Employee_ID == employee.Employee_ID || (em.FirstName.Equals(employee.FirstName) && em.LastName.Equals(employee.LastName)));
                    if (emp == null)
                    {
                        db.EmpList.Add(employee);
                        db.SaveChanges();
                    }
                    else {
                    throw new EmployeeAlreadyExistException("The employee-Id " + emp.Employee_ID + " or the name " + emp.FirstName + " " + emp.LastName + " Already exist in the Database");
                   }
                    
                }
            
        }
        /// <summary>
        /// delete a single employee in the Database
        /// </summary>
        /// <param name="Employee_Id"></param>
        public void DeleteEmployee(string Employee_Id)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                var employee = db.EmpList.SingleOrDefault(emp => emp.Employee_ID == Employee_Id);
                if (employee != null)
                {
                    db.EmpList.Remove(employee);
                    db.SaveChanges();
                }
                else
                {
                    throw new EmployeeNotFoundException(" No employee with the Id: " +Employee_Id + " found in  the Database!");
                }
                
            }
        }
        /// <summary>
        /// getting Employee by Id
        /// </summary>
        /// <param name="Employee_Id"></param>
        /// <returns></returns>
        public Employee GetEmployeeById(string Employee_Id)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                var employee = db.EmpList.SingleOrDefault(emp => emp.Employee_ID.Equals(Employee_Id));
                return employee;
               
            }
        }
        /// <summary>
        /// Update employee from  the database
        /// </summary>
        /// <param name="employee"></param>
        public void UpdateEmployee(Employee employee)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                var remployee = db.EmpList.SingleOrDefault(emp => emp.Employee_ID.Equals(employee.Employee_ID));
                if (employee != null && remployee!=null)
                {
                    remployee.Gender = employee.Gender;
                    remployee.FirstName = employee.FirstName;
                    remployee.LastName = employee.LastName;
                    remployee.Department_Id = employee.Department_Id;
                    remployee.Email = employee.Email;
                    remployee.address = employee.address;
                    remployee.Design = employee.Design;
                    remployee.Date_today = employee.Date_today;
                    remployee.Date_from = employee.Date_from;
                    remployee.Date_to = employee.Date_to;
                    remployee.shift = employee.shift;

                    db.SaveChanges();

                }
            }
        }

        /// <summary>
        /// Method to add department in the Database
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public int AddDepartment(Department department)
        {          
            using(EmployeeContext db = new EmployeeContext())
            {
                int idDepartment; 
                var departname = db.DepartmentList.FirstOrDefault(depart => depart.Name.ToLower().Equals(department.Name.ToLower()));
                if (departname == null)
                {
                    db.DepartmentList.Add(department);
                    db.SaveChanges();
                    idDepartment = department.Department_Id;
                }
                else
                {
                    idDepartment = departname.Department_Id;
                }

                return idDepartment;
            }
        }
        /// <summary>
        /// get Department by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetDepartmentById(int id)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                string departName = null;
                var department = db.DepartmentList.FirstOrDefault(depart => depart.Department_Id == id);
                departName = department.Name;
                return departName;
            }
        }
        /// <summary>
        /// getting all employees from  Database
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employeeList = null;
            using (EmployeeDataClassDataContext db = new EmployeeDataClassDataContext())
            {
                var data = from emp in db.tblEmployees
                           select new Employee
                           {
                            Emp_ID = emp.Emp_ID,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            Design = emp.Design,
                            Email = emp.Email,
                            address = emp.address,
                            Gender = emp.Gender,
                            Employee_ID = emp.Employee_ID,
                            Date_today = emp.Date_today,
                            Date_from = emp.Date_from,
                            Date_to = emp.Date_to,
                            shift = emp.shift,
                            Department_Id = emp.Department_Id,                            
                           };
                if (data.Count() > 0) employeeList= data.ToList<Employee>();
                
            }
            return employeeList;
        }
    }
}
