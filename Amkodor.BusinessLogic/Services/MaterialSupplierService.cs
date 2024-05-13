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
    public class MaterialSupplierService : IMaterialSupplierService
    {
        private readonly IMaterialSupplierRepository _materialSupplierRepository;

        public MaterialSupplierService(IMaterialSupplierRepository materialSupplierRepository)
        {
            _materialSupplierRepository = materialSupplierRepository;
        }

        public IEnumerable<MaterialSupplier> GetAllMaterialsSuppliers()
        {
            return _materialSupplierRepository.GetAllMaterialsSuppliers();
        }

        public IEnumerable<MaterialSupplier> GetAllMaterialsSupBySupplierId(int supplierId)
        {
            return _materialSupplierRepository.GetAllMaterialsSupBySupplierId(supplierId);
        }

        public IEnumerable<MaterialSupplier> Search(string value)
        {
            return _materialSupplierRepository.Search(value);
        }

        public void Add(MaterialSupplier materialSupplier)
        {
            _materialSupplierRepository.Add(materialSupplier);
        }

        public void Edit(MaterialSupplier materialSupplier)
        {
            _materialSupplierRepository.Edit(materialSupplier);
        }

        public void Delete(MaterialSupplier materialSupplier)
        {
            _materialSupplierRepository.Delete(materialSupplier);
        }
    }
}
