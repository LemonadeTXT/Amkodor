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

        public void Add(Supplier supplier)
        {
            _applicationContext.Suppliers.Add(supplier);
            _applicationContext.SaveChanges();
        }

        public void Edit(Supplier supplier)
        {
            _applicationContext.Suppliers.Update(supplier);
            _applicationContext.SaveChanges();
        }

        public void Delete(Supplier supplier)
        {
            _applicationContext.Suppliers.Remove(supplier);
            _applicationContext.SaveChanges();
        }
    }
}
