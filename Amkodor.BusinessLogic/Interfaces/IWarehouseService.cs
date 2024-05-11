using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.BusinessLogic.Interfaces
{
    public interface IWarehouseService
    {
        IEnumerable<Warehouse> GetAllWarehouses();

        void Add(Warehouse warehouse);

        void Edit(Warehouse warehouse);

        void Delete(Warehouse warehouse);
    }
}
