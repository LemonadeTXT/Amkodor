using Amkodor.DAL.Interfaces;
using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.DAL.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly ApplicationContext _applicationContext;

        public WarehouseRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<Warehouse> GetAllWarehouses()
        {
            var warehouses = _applicationContext.Warehouses.ToList();

            return warehouses;
        }

        public void Add(Warehouse warehouse)
        {
            _applicationContext.Warehouses.Add(warehouse);
            _applicationContext.SaveChanges();
        }

        public void Edit(Warehouse warehouse)
        {
            _applicationContext.Warehouses.Update(warehouse);
            _applicationContext.SaveChanges();
        }

        public void Delete(Warehouse warehouse)
        {
            _applicationContext.Warehouses.Remove(warehouse);
            _applicationContext.SaveChanges();
        }
    }
}
