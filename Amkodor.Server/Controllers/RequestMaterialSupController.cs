using Amkodor.BusinessLogic.Interfaces;
using Amkodor.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amkodor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestMaterialSupController : Controller
    {
        private readonly IRequestMaterialSupService _requestMaterialSupService;

        public RequestMaterialSupController(IRequestMaterialSupService requestMaterialSupService)
        {
            _requestMaterialSupService = requestMaterialSupService;
        }

        [HttpGet]
        public async Task<IEnumerable<RequestMaterialSupplier>> GetAllRequestMaterialsSups()
        {
            try
            {
                return _requestMaterialSupService.GetAllRequestMaterialsSups();
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("search")]
        public async Task<IEnumerable<RequestMaterialSupplier>> Search([FromBody] string value)
        {
            return _requestMaterialSupService.Search(value);
        }

        [HttpPost]
        [Route("add")]
        public void Add(RequestMaterialSupplier requestMaterialSupplier)
        {
            try
            {
                _requestMaterialSupService.Add(requestMaterialSupplier);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("edit")]
        public void Edit(RequestMaterialSupplier requestMaterialSupplier)
        {
            try
            {
                _requestMaterialSupService.Edit(requestMaterialSupplier);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("delete")]
        public void Delete(RequestMaterialSupplier requestMaterialSupplier)
        {
            try
            {
                _requestMaterialSupService.Delete(requestMaterialSupplier);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
