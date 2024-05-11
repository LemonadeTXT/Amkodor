using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.DAL.Interfaces
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetAllSuppliers();

        void Add(Supplier supplier);

        void Edit(Supplier supplier);

        void Delete(Supplier supplier);
    }
}
