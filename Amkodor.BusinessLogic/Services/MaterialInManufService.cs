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
    public class MaterialInManufService : IMaterialInManufService
    {
        private readonly IMaterialInManufRepository _materialInManufRepository;

        public MaterialInManufService(IMaterialInManufRepository materialInManufRepository)
        {
            _materialInManufRepository = materialInManufRepository;
        }

        public IEnumerable<MaterialInManufacturing> GetAllMaterialsInManufacturing()
        {
            return _materialInManufRepository.GetAllMaterialsInManufacturing();
        }

        public IEnumerable<MaterialInManufacturing> Search(string value)
        {
            return _materialInManufRepository.Search(value);
        }

        public void Add(MaterialInManufacturing materialInManufacturing)
        {
            _materialInManufRepository.Add(materialInManufacturing);
        }

        public void Edit(MaterialInManufacturing materialInManufacturing)
        {
            _materialInManufRepository.Edit(materialInManufacturing);
        }

        public void Delete(MaterialInManufacturing materialInManufacturing)
        {
            _materialInManufRepository.Delete(materialInManufacturing);
        }
    }
}
