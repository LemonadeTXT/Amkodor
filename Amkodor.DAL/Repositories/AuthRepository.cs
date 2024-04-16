using Amkodor.Common.DTOs;
using Amkodor.DAL.Interfaces;
using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.DAL.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationContext _applicationContext;

        public AuthRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public User Auth(UserDto userDto)
        {
            var foundUser = _applicationContext.Users.FirstOrDefault(i => i.Login == userDto.Login);

            return foundUser;
        }
    }
}
