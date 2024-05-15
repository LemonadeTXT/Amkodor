using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.BusinessLogic.Interfaces
{
    public interface IMaterialInManufService
    {
        IEnumerable<MaterialInManufacturing> GetAllMaterialsInManufacturing();

        IEnumerable<MaterialInManufacturing> Search(string value);

        void Add(MaterialInManufacturing materialInManufacturing);

        void Edit(MaterialInManufacturing materialInManufacturing);

        void Delete(MaterialInManufacturing materialInManufacturing);
    }
}
