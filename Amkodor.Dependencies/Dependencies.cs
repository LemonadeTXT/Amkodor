using Amkodor.BusinessLogic.Interfaces;
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
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<IMaterialSupplierService, MaterialSupplierService>();
            services.AddTransient<IWarehouseService, WarehouseService>();
            services.AddTransient<IMaterialService, MaterialService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IRequestMaterialSupService, RequestMaterialSupService>();
            services.AddTransient<IProductInManufService, ProductInManufService>();
        }

        public static void AddIRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<IMaterialSupplierRepository, MaterialSupplierRepository>();
            services.AddTransient<IWarehouseRepository, WarehouseRepository>();
            services.AddTransient<IMaterialRepository, MaterialRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IRequestMaterialSupRepository, RequestMaterialSupRepository>();
            services.AddTransient<IProductInManufRepository, ProductInManufRepository>();
        }
    }
}
