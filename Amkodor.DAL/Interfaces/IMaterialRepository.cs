using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.DAL.Interfaces
{
    public interface IMaterialRepository
    {
        IEnumerable<Material> GetAllMaterials();

        IEnumerable<Material> GetAllMaterialsByWarehouseId(int warhouseId);

        IEnumerable<Material> Search(string value);

        void Add(Material material);

        void Edit(Material material);

        void Delete(Material material);
    }
}
