using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.DAL.Interfaces
{
    public interface IRequestMaterialSupRepository
    {
        IEnumerable<RequestMaterialSupplier> GetAllRequestMaterialsSups();

        IEnumerable<RequestMaterialSupplier> Search(string value);

        void Add(RequestMaterialSupplier requestMaterialSupplier);

        void Edit(RequestMaterialSupplier requestMaterialSupplier);

        void Delete(RequestMaterialSupplier requestMaterialSupplier);
    }
}
