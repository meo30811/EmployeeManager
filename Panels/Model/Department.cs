using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panels.Model
{
    [Table("tblDepartments")]
    public class Department
    {
        [Key]
        public int Department_Id {get; set;}
        public string Name { get; set; }
    }
}
