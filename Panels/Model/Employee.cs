using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Panels.Model
{
    [Table("tblEmployees")]
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int Emp_ID { get; set; }
        [Required(ErrorMessage ="Firstname is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Designation is required")]
        public string Design { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public string address { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Employee_id is required")]
        public string Employee_ID { get; set;}
        public DateTime Date_today { get;  set; }
        public DateTime Date_from { get; set; }
        public DateTime Date_to { get; set; }
        [Required(ErrorMessage = "Shift is required")]
        public string shift { get; set; }
        [ForeignKey("Department")]
        public int Department_Id { get; set; }
        public Department Department { get; set;}

      
    }
}
