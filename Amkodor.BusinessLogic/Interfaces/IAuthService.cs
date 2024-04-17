﻿using Amkodor.Common.DTOs;
using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.BusinessLogic.Interfaces
{
    public interface IAuthService
    {
        bool IsAuth(UserDto userDto);
    }
}
