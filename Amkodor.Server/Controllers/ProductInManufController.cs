using Amkodor.BusinessLogic.Interfaces;
using Amkodor.BusinessLogic.Services;
using Amkodor.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amkodor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductInManufController : Controller
    {
        private readonly IProductInManufService _productInManufService;

        public ProductInManufController(IProductInManufService productInManufService)
        {
            _productInManufService = productInManufService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductInManufacturing>> GetAllProductsInManufacturing()
        {
            try
            {
                return _productInManufService.GetAllProductsInManufacturing();
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("add")]
        public void Add(ProductInManufacturing productInManufacturing)
        {
            try
            {
                _productInManufService.Add(productInManufacturing);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("edit")]
        public void Edit(ProductInManufacturing productInManufacturing)
        {
            try
            {
                _productInManufService.Edit(productInManufacturing);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("delete")]
        public void Delete(ProductInManufacturing productInManufacturing)
        {
            try
            {
                _productInManufService.Delete(productInManufacturing);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
