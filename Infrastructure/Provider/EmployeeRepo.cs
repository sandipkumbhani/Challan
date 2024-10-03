using Domain.Interface;
using Domain.Model;
using MultiLang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Infrastructure.Provider
{
    public class EmployeeRepo : IEmployeeRepo
    {

        private readonly AppDBContext _context;
        public EmployeeRepo(AppDBContext context)
        {
            _context= context;
        }
        public EmployeeViewModel addEmployee(EmployeeViewModel employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
            return employee; 
            
        }
    }
}

