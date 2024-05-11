using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.BusinessLogic.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAllSuppliers();

        void Add(Supplier supplier);

        void Edit(Supplier supplier);

        void Delete(Supplier supplier);
    }
}
