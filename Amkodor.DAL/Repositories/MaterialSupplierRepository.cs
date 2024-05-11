using Amkodor.DAL.Interfaces;
using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.DAL.Repositories
{
    public class MaterialSupplierRepository : IMaterialSupplierRepository
    {
        private readonly ApplicationContext _applicationContext;

        public MaterialSupplierRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<MaterialSupplier> GetAllMaterialsSuppliers()
        {
            var materialsSuppliers = _applicationContext.MaterialsSuppliers.ToList();

            return materialsSuppliers;
        }

        public IEnumerable<MaterialSupplier> GetAllMaterialsSupBySupplierId(int supplierId)
        {
            var materialsSuppliers = _applicationContext.MaterialsSuppliers.Where(ms => ms.SupplierId == supplierId).ToList();

            return materialsSuppliers;
        }
    }
}
