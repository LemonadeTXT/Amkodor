using Amkodor.DAL.Interfaces;
using Amkodor.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.DAL.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly ApplicationContext _applicationContext;

        public MaterialRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<Material> GetAllMaterials()
        {
            var materials = _applicationContext.Materials.ToList();

            return materials;
        }

        public IEnumerable<Material> GetAllMaterialsByWarehouseId(int warhouseId)
        {
            var materials = _applicationContext.Materials.Where(m => m.WarehouseId == warhouseId).ToList();

            return materials;
        }

        public IEnumerable<Material> Search(string value)
        {
            var foundMaterials = new List<Material>();

            value = value.Trim().ToLower();

            var materials = _applicationContext.Materials.AsQueryable();

            foreach (var material in materials)
            {
                if (material.Id.ToString().Contains(value) ||
                    material.Name.ToLower().Contains(value) ||
                    material.Type.ToString().Contains(value) ||
                    material.Unit.ToString().Contains(value) ||
                    material.WarehouseId.ToString().Contains(value))
                {
                    foundMaterials.Add(material);
                }
            }

            return foundMaterials;
        }

        public void Add(Material material)
        {
            _applicationContext.Materials.Add(material);
            _applicationContext.SaveChanges();
        }

        public void Edit(Material material)
        {
            _applicationContext.Materials.Update(material);
            _applicationContext.SaveChanges();
        }

        public void Delete(Material material)
        {
            _applicationContext.Materials.Remove(material);
            _applicationContext.SaveChanges();
        }
    }
}
