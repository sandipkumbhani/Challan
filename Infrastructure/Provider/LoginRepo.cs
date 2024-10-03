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
    public class LoginRepo : ILoginRepo
    {
        private readonly AppDBContext _context;
        public LoginRepo(AppDBContext context)
        {
            _context = context;
        }

        public UserViewModel AddUser(UserViewModel model)
        {
            _context.Add(model);
            _context.SaveChanges(); 
            return model;
        }

        public UserViewModel Login(UserViewModel model)
        {
            return _context.User.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
        }
    }
}
