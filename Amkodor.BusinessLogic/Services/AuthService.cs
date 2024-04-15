using Amkodor.BusinessLogic.Interfaces;
using Amkodor.Common.DTOs;
using Amkodor.DAL;
using Amkodor.DAL.Repositories;
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
        private readonly AuthRepository _authRepository;
        private readonly HashService _hashService;

        public AuthService()
        {
            _authRepository = new AuthRepository();
            _hashService = new HashService();
        }

        public bool Auth(UserDto userDto)
        {
            var foundUser = _authRepository.Auth(userDto);

            var isAuth = _hashService.VerifyPasswordHash(userDto.Password, foundUser?.PasswordHash, foundUser?.PasswordSalt);

            return isAuth;
        }
    }
}
