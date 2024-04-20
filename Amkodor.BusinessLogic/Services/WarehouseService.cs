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
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public IEnumerable<Warehouse> GetAllWarehouses()
        {
            return _warehouseRepository.GetAllWarehouses();
        }
    }
}
