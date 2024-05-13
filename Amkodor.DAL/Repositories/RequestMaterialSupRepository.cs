using Amkodor.DAL.Interfaces;
using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.DAL.Repositories
{
    public class RequestMaterialSupRepository : IRequestMaterialSupRepository
    {
        private readonly ApplicationContext _applicationContext;

        public RequestMaterialSupRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<RequestMaterialSupplier> GetAllRequestMaterialsSups()
        {
            var requestMaterialsSuppliers = _applicationContext.RequestMaterialsSuppliers.ToList();

            return requestMaterialsSuppliers;
        }

        public IEnumerable<RequestMaterialSupplier> Search(string value)
        {
            var foundRequestMaterials = new List<RequestMaterialSupplier>();

            value = value.Trim().ToLower();

            var requestMaterials = _applicationContext.RequestMaterialsSuppliers.AsQueryable();

            foreach (var requestMaterial in requestMaterials)
            {
                if (requestMaterial.Id.ToString().Contains(value) ||
                    requestMaterial.Name.ToLower().Contains(value) ||
                    requestMaterial.Type.Value.ToString().ToLower().Contains(value) ||
                    requestMaterial.Unit.Value.ToString().ToLower().Contains(value) ||
                    requestMaterial.PriceForOne.ToString().Contains(value) ||
                    requestMaterial.Count.ToString().Contains(value) ||
                    requestMaterial.ArrivalDate.ToString().Contains(value) ||
                    requestMaterial.Approve.ToString().Contains(value) ||
                    requestMaterial.SupplierId.ToString().Contains(value))
                {
                    foundRequestMaterials.Add(requestMaterial);
                }
            }

            return foundRequestMaterials;
        }

        public void Add(RequestMaterialSupplier requestMaterialSupplier)
        {
            _applicationContext.RequestMaterialsSuppliers.Add(requestMaterialSupplier);
            _applicationContext.SaveChanges();
        }

        public void Edit(RequestMaterialSupplier requestMaterialSupplier)
        {
            _applicationContext.RequestMaterialsSuppliers.Update(requestMaterialSupplier);
            _applicationContext.SaveChanges();
        }

        public void Delete(RequestMaterialSupplier requestMaterialSupplier)
        {
            _applicationContext.RequestMaterialsSuppliers.Remove(requestMaterialSupplier);
            _applicationContext.SaveChanges();
        }
    }
}
