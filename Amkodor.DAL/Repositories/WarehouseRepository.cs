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
    }
}
