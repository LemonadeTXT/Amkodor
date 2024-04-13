﻿using Amkodor.BusinessLogic.Interfaces;
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
    public class AuthService : IAuthService
    {
        private readonly ApplicationContext _applicationContext;
        private readonly HashService _hashService;

        public AuthService()
        {
            _applicationContext = new ApplicationContext();
            _hashService = new HashService();
        }

        public bool Auth(UserDto userDto)
        {
            var foundUser = _applicationContext.Users.FirstOrDefault(i => i.Login == userDto.Login);

            var isAuth = _hashService.VerifyPasswordHash(userDto.Password, foundUser?.PasswordHash, foundUser?.PasswordSalt);

            return isAuth;
        }
    }
}
