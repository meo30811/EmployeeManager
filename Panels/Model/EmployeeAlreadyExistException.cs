using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panels.Model
{
    class EmployeeAlreadyExistException: Exception
    {
        public EmployeeAlreadyExistException()
        {

        }
        public EmployeeAlreadyExistException(string errorMessage, System.Exception inner)
            :base(errorMessage, inner)
        {

        }
        public EmployeeAlreadyExistException( string errMessage)
            :base(errMessage)
        {

        }
    }
}
