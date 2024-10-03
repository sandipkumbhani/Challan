using Application.Interface;
using Domain.Interface;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Providers
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepo _loginRepo;
        public LoginService(ILoginRepo loginRepo)
        {
            _loginRepo=loginRepo;
        }

        public UserViewModel Add(UserViewModel model)
        {
           return _loginRepo.AddUser(model);
        }

        public UserViewModel Login(UserViewModel model)
        {
           return _loginRepo.Login(model);
        }
    }
}
