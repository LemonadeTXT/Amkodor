using Amkodor.DAL.Interfaces;
using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _applicationContext;

        public ProductRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = _applicationContext.Products.ToList();

            return products;
        }

        public IEnumerable<Product> Search(string value)
        {
            var foundProducts = new List<Product>();

            value = value.Trim().ToLower();

            var products = _applicationContext.Products.AsQueryable();

            foreach (var product in products)
            {
                if (product.Id.ToString().Contains(value) ||
                    product.Name.ToLower().Contains(value) ||
                    product.Model.ToLower().Contains(value) ||
                    product.CostPrice.ToString().Contains(value) ||
                    product.BuildDate.ToString().Contains(value))
                {
                    foundProducts.Add(product);
                }
            }

            return foundProducts;
        }

        public void Add(Product product)
        {
            _applicationContext.Products.Add(product);
            _applicationContext.SaveChanges();
        }

        public void Edit(Product product)
        {
            _applicationContext.Products.Update(product);
            _applicationContext.SaveChanges();
        }

        public void Delete(Product product)
        {
            _applicationContext.Products.Remove(product);
            _applicationContext.SaveChanges();
        }
    }
}
