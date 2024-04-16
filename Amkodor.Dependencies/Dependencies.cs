﻿using Amkodor.BusinessLogic.Interfaces;
using Amkodor.BusinessLogic.Services;
using Amkodor.DAL.Interfaces;
using Amkodor.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.Dependencies
{
    public static class Dependencies
    {
        public static void AddIServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IHashService, HashService>();
        }

        public static void AddIRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAuthRepository, AuthRepository>();
        }
    }
}