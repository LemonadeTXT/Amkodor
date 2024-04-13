using Amkodor.BusinessLogic.Interfaces;
using Amkodor.Common.DTOs;
using Amkodor.DAL;
using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _applicationContext;
        private readonly HashService _hashService;

        public UserService()
        {
            _applicationContext = new ApplicationContext();
            _hashService = new HashService();
        }

        public void Edit(UserDto userDto)
        {
            _hashService.CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                Login = userDto.Login,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _applicationContext.Users.Update(user);

            _applicationContext.SaveChanges();
        }
    }
}
