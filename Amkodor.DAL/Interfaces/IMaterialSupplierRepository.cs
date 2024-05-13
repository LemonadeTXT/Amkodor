using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.DAL.Interfaces
{
    public interface IMaterialSupplierRepository
    {
        IEnumerable<MaterialSupplier> GetAllMaterialsSuppliers();

        IEnumerable<MaterialSupplier> GetAllMaterialsSupBySupplierId(int supplierId);

        IEnumerable<MaterialSupplier> Search(string value);

        void Add(MaterialSupplier materialSupplier);

        void Edit(MaterialSupplier materialSupplier);

        void Delete(MaterialSupplier materialSupplier);
    }
}
