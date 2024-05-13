using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.DAL.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        IEnumerable<Product> Search(string value);

        void Edit(Product product);

        void Delete(Product product);
    }
}
