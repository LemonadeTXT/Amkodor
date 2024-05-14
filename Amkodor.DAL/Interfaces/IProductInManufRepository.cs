using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.DAL.Interfaces
{
    public interface IProductInManufRepository
    {
        IEnumerable<ProductInManufacturing> GetAllProductsInManufacturing();

        void Add(ProductInManufacturing productInManufacturing);

        void Edit(ProductInManufacturing productInManufacturing);

        void Delete(ProductInManufacturing productInManufacturing);
    }
}
