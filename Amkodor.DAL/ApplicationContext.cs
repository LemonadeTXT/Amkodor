using Amkodor.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialInManufacturing> MaterialsInManufacturing { get; set; }
        public DbSet<MaterialSupplier> MaterialsSuppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInManufacturing> ProductsInManufacturing { get; set; }
        public DbSet<RequestMaterialSupplier> RequestMaterialsSuppliers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
    }
}
