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
    public class RequestMaterialSupService : IRequestMaterialSupService
    {
        private readonly IRequestMaterialSupRepository _requestMaterialSupRepository;

        public RequestMaterialSupService(IRequestMaterialSupRepository requestMaterialSupRepository)
        {
            _requestMaterialSupRepository = requestMaterialSupRepository;
        }

        public IEnumerable<RequestMaterialSupplier> GetAllRequestMaterialsSups()
        {
            return _requestMaterialSupRepository.GetAllRequestMaterialsSups();
        }

        public IEnumerable<RequestMaterialSupplier> Search(string value)
        {
            return _requestMaterialSupRepository.Search(value);
        }

        public void Add(RequestMaterialSupplier requestMaterialSupplier)
        {
            _requestMaterialSupRepository.Add(requestMaterialSupplier);
        }

        public void Edit(RequestMaterialSupplier requestMaterialSupplier)
        {
            _requestMaterialSupRepository.Edit(requestMaterialSupplier);
        }

        public void Delete(RequestMaterialSupplier requestMaterialSupplier)
        {
            _requestMaterialSupRepository.Delete(requestMaterialSupplier);
        }
    }
}
