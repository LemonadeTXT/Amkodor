using Amkodor.DAL.Interfaces;
using Amkodor.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.DAL.Repositories
{
    public class ProductInManufRepository : IProductInManufRepository
    {
        private readonly ApplicationContext _applicationContext;

        public ProductInManufRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<ProductInManufacturing> GetAllProductsInManufacturing()
        {
            var productsInManufacturing = _applicationContext.ProductsInManufacturing.ToList();

            return productsInManufacturing;
        }

        public IEnumerable<ProductInManufacturing> GetAllActiveProductsInManufacturing()
        {
            var productsInManufacturing = _applicationContext.ProductsInManufacturing.
                Where(pm => pm.InManufacturing == true).
                Include(pm => pm.Employees).
                Include(pm => pm.MaterialInManufacturing).ToList();

            return productsInManufacturing;
        }

        public IEnumerable<ProductInManufacturing> GetAllInactiveProductsInManufacturing()
        {
            var productsInManufacturing = _applicationContext.ProductsInManufacturing.
                Where(pm => pm.InManufacturing == false).
                Include(pm => pm.Employees).
                Include(pm => pm.MaterialInManufacturing).ToList();

            return productsInManufacturing;
        }

        public ProductInManufacturing GetInactiveProdInManufById(int id)
        {
            var prodInManufById = _applicationContext.ProductsInManufacturing.
                Include(pm => pm.Employees).
                Include(pm => pm.MaterialInManufacturing).
                FirstOrDefault(pm => pm.Id == id && pm.InManufacturing == false);

            return prodInManufById;
        }

        public void Add(ProductInManufacturing productInManufacturing)
        {
            _applicationContext.ProductsInManufacturing.Add(productInManufacturing);
            _applicationContext.SaveChanges();
        }

        public void Edit(ProductInManufacturing productInManufacturing)
        {
            _applicationContext.ProductsInManufacturing.Update(productInManufacturing);
            _applicationContext.SaveChanges();
        }

        public void Delete(ProductInManufacturing productInManufacturing)
        {
            _applicationContext.ProductsInManufacturing.Remove(productInManufacturing);
            _applicationContext.SaveChanges();
        }
    }
}
