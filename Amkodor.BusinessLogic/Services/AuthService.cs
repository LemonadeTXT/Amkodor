using Amkodor.BusinessLogic.Interfaces;
using Amkodor.Common.DTOs;
using Amkodor.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IHashService _hashService;

        public AuthService(IAuthRepository authRepository, IHashService hashService)
        {
            _authRepository = authRepository;
            _hashService = hashService;
        }

        public bool IsAuth(UserDto userDto)
        {
            var foundUser = _authRepository.IsAuth(userDto);

            var isAuth = _hashService.VerifyPasswordHash(userDto.Password, foundUser?.PasswordHash, foundUser?.PasswordSalt);

            return isAuth;
        }
    }
}
