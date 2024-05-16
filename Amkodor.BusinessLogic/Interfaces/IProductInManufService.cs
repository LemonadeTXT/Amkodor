using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.BusinessLogic.Interfaces
{
    public interface IProductInManufService
    {
        IEnumerable<ProductInManufacturing> GetAllProductsInManufacturing();

        IEnumerable<ProductInManufacturing> GetAllActiveProductsInManufacturing();

        IEnumerable<ProductInManufacturing> GetAllInactiveProductsInManufacturing();

        ProductInManufacturing GetActiveProdInManufById(int id);

        ProductInManufacturing GetInactiveProdInManufById(int id);

        void Add(ProductInManufacturing productInManufacturing);

        void Edit(ProductInManufacturing productInManufacturing);

        void EditTarget(ProductInManufacturing productInManufacturing);

        void Delete(ProductInManufacturing productInManufacturing);
    }
}
