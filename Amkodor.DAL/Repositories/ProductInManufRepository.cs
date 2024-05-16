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

        public ProductInManufacturing GetActiveProdInManufById(int id)
        {
            var prodInManufById = _applicationContext.ProductsInManufacturing.
                Include(pm => pm.Employees).
                Include(pm => pm.MaterialInManufacturing).
                FirstOrDefault(pm => pm.Id == id && pm.InManufacturing == true);

            return prodInManufById;
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

        public void EditTarget(ProductInManufacturing productInManufacturing)
        {
            _applicationContext.ProductsInManufacturing.
                Where(pm => pm.Id ==  productInManufacturing.Id).
                ExecuteUpdate(s => s.
                SetProperty(pm => pm.Name, pm => productInManufacturing.Name).
                SetProperty(pm => pm.Model, pm => productInManufacturing.Model).
                SetProperty(pm => pm.Readiness, pm => productInManufacturing.Readiness).
                SetProperty(pm => pm.DeadLine, pm => productInManufacturing.DeadLine).
                SetProperty(pm => pm.InManufacturing, pm => productInManufacturing.InManufacturing));
            _applicationContext.SaveChanges();
        }

        public void Delete(ProductInManufacturing productInManufacturing)
        {
            _applicationContext.ProductsInManufacturing.Remove(productInManufacturing);
            _applicationContext.SaveChanges();
        }
    }
}
