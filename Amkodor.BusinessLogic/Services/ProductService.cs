using Amkodor.BusinessLogic.Interfaces;
using Amkodor.DAL.Interfaces;
using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public IEnumerable<Product> Search(string value)
        {
            return _productRepository.Search(value);
        }

        public void Edit(Product product)
        {
            _productRepository.Edit(product);
        }

        public void Delete(Product product)
        {
            _productRepository.Delete(product);
        }
    }
}
