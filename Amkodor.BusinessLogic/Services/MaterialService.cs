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
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public IEnumerable<Material> GetAllMaterials()
        {
            return _materialRepository.GetAllMaterials();
        }

        public IEnumerable<Material> GetAllMaterialsByWarehouseId(int warhouseId)
        {
            return _materialRepository.GetAllMaterialsByWarehouseId(warhouseId);
        }

        public IEnumerable<Material> Search(string value)
        {
            return _materialRepository.Search(value);
        }

        public void Add(Material material)
        {
            _materialRepository.Add(material);
        }

        public void Edit(Material material)
        {
            _materialRepository.Edit(material);
        }

        public void Delete(Material material)
        {
            _materialRepository.Delete(material);
        }
    }
}
