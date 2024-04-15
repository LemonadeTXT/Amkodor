using Amkodor.Models.Models;
using Amkodor.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.DAL.Interfaces
{
    public interface IAuthRepository
    {
        User Auth(UserDto userDto);
    }
}
