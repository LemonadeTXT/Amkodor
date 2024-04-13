using Amkodor.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.BusinessLogic.Services
{
    public class HashService : IHashService
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            var hmac = new HMACSHA512();
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            passwordSalt = hmac.Key;
        }

        public bool VerifyPasswordHash(string? password, byte[]? passwordHash, byte[]? passwordSalt)
        {
            var hmac = new HMACSHA512(passwordSalt!);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password!));

            return hash.SequenceEqual(passwordHash!);
        }
    }
}
