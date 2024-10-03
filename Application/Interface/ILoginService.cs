using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ILoginService
    {
        public UserViewModel Login(UserViewModel model);

        public UserViewModel Add(UserViewModel model);
    }
}
