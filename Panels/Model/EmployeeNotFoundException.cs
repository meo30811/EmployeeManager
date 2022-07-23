using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panels.Model
{
    class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException()
        {

        }
        public EmployeeNotFoundException(string errorMessage)
            :base(errorMessage)
        {

        }
    }
}
