using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Domain.Interface;
using Domain.Model;

namespace Application.Providers
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepo _employee;
        public EmployeeServices(IEmployeeRepo employee)
        {
            _employee = employee;
        }
        public EmployeeViewModel AddEmployee(EmployeeViewModel model)
        {
            return _employee.addEmployee(model);    
        }
    }
}
