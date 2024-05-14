using Amkodor.DAL.Interfaces;
using Amkodor.Models.Models;
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
