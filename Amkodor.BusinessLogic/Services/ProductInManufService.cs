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
    public class ProductInManufService : IProductInManufService
    {
        private readonly IProductInManufRepository _productInManufRepository;

        public ProductInManufService(IProductInManufRepository productInManufRepository)
        {
            _productInManufRepository = productInManufRepository;
        }

        public IEnumerable<ProductInManufacturing> GetAllProductsInManufacturing()
        {
            return _productInManufRepository.GetAllProductsInManufacturing();
        }

        public IEnumerable<ProductInManufacturing> GetAllActiveProductsInManufacturing()
        {
            return _productInManufRepository.GetAllActiveProductsInManufacturing();
        }

        public IEnumerable<ProductInManufacturing> GetAllInactiveProductsInManufacturing()
        {
            return _productInManufRepository.GetAllInactiveProductsInManufacturing();
        }

        public ProductInManufacturing GetActiveProdInManufById(int id)
        {
            return _productInManufRepository.GetActiveProdInManufById(id);
        }

        public ProductInManufacturing GetInactiveProdInManufById(int id)
        {
            return _productInManufRepository.GetInactiveProdInManufById(id);
        }

        public void Add(ProductInManufacturing productInManufacturing)
        {
            _productInManufRepository.Add(productInManufacturing);
        }

        public void Edit(ProductInManufacturing productInManufacturing)
        {
            _productInManufRepository.Edit(productInManufacturing);
        }

        public void EditTarget(ProductInManufacturing productInManufacturing)
        {
            _productInManufRepository.EditTarget(productInManufacturing);
        }

        public void Delete(ProductInManufacturing productInManufacturing)
        {
            _productInManufRepository.Delete(productInManufacturing);
        }
    }
}
