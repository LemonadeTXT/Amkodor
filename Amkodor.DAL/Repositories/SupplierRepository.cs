using Amkodor.DAL.Interfaces;
using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.DAL.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationContext _applicationContext;

        public SupplierRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            var suppliers = _applicationContext.Suppliers.ToList();

            return suppliers;
        }
    }
}
