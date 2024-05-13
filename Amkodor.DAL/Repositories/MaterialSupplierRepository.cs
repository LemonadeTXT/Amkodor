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

        public IEnumerable<MaterialSupplier> Search(string value)
        {
            var foundMaterialsSuppliers = new List<MaterialSupplier>();

            value = value.Trim().ToLower();

            var materialsSuppliers = _applicationContext.MaterialsSuppliers.AsQueryable();

            foreach (var materialSupplier in materialsSuppliers)
            {
                if (materialSupplier.Id.ToString().Contains(value) ||
                    materialSupplier.Name.ToLower().Contains(value) ||
                    materialSupplier.Type.Value.ToString().ToLower().Contains(value) ||
                    materialSupplier.Unit.Value.ToString().ToLower().Contains(value) || 
                    materialSupplier.PriceForOne.ToString().Contains(value) || 
                    materialSupplier.SupplierId.ToString().Contains(value))
                {
                    foundMaterialsSuppliers.Add(materialSupplier);
                }
            }

            return foundMaterialsSuppliers;
        }

        public void Add(MaterialSupplier materialSupplier)
        {
            _applicationContext.MaterialsSuppliers.Add(materialSupplier);
            _applicationContext.SaveChanges();
        }

        public void Edit(MaterialSupplier materialSupplier)
        {
            _applicationContext.MaterialsSuppliers.Update(materialSupplier);
            _applicationContext.SaveChanges();
        }

        public void Delete(MaterialSupplier materialSupplier)
        {
            _applicationContext.MaterialsSuppliers.Remove(materialSupplier);
            _applicationContext.SaveChanges();
        }
    }
}
