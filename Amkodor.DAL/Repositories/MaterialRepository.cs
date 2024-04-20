using Amkodor.DAL.Interfaces;
using Amkodor.Models.Models;
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
    }
}
