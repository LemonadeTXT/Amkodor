using Amkodor.DAL.Interfaces;
using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.DAL.Repositories
{
    public class MaterialInManufRepository : IMaterialInManufRepository
    {
        private readonly ApplicationContext _applicationContext;

        public MaterialInManufRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<MaterialInManufacturing> GetAllMaterialsInManufacturing()
        {
            var materialsInManuf = _applicationContext.MaterialsInManufacturing.ToList();

            return materialsInManuf;
        }

        public IEnumerable<MaterialInManufacturing> Search(string value)
        {
            var foundMaterialsInManuf = new List<MaterialInManufacturing>();

            value = value.Trim().ToLower();

            var materialsInManuf = _applicationContext.MaterialsInManufacturing.AsQueryable();

            foreach (var materialInManuf in materialsInManuf)
            {
                if (materialInManuf.Id.ToString().Contains(value) ||
                    materialInManuf.Name.ToLower().Contains(value) ||
                    materialInManuf.Type.Value.ToString().ToLower().Contains(value) ||
                    materialInManuf.Unit.Value.ToString().ToLower().Contains(value) ||
                    materialInManuf.Count.ToString().Contains(value) ||
                    materialInManuf.WarehouseId.ToString().Contains(value) || 
                    materialInManuf.ProductInManufacturingId.ToString().Contains(value))
                {
                    foundMaterialsInManuf.Add(materialInManuf);
                }
            }

            return foundMaterialsInManuf;
        }

        public void Add(MaterialInManufacturing materialInManufacturing)
        {
            _applicationContext.MaterialsInManufacturing.Add(materialInManufacturing);
            _applicationContext.SaveChanges();
        }

        public void Edit(MaterialInManufacturing materialInManufacturing)
        {
            _applicationContext.MaterialsInManufacturing.Update(materialInManufacturing);
            _applicationContext.SaveChanges();
        }

        public void Delete(MaterialInManufacturing materialInManufacturing)
        {
            _applicationContext.MaterialsInManufacturing.Remove(materialInManufacturing);
            _applicationContext.SaveChanges();
        }
    }
}
