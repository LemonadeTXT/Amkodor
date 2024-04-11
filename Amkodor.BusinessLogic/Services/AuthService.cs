using Amkodor.BusinessLogic.Interfaces;
using Amkodor.DAL;
using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationContext _applicationContext;

        public AuthService()
        {
            _applicationContext = new ApplicationContext();
        }

        public bool Auth(User user)
        {
            var findUser = _applicationContext.Users.Any(i => i.Login == user.Login && i.Password == user.Password);

            return findUser;
        }
    }
}
