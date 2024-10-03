using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;
using Domain.Model;

namespace Application.Interface
{
    public interface IEmployeeServices
    {
        public EmployeeViewModel AddEmployee(EmployeeViewModel model);
        
    }
}
