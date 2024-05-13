using Amkodor.BusinessLogic.Interfaces;
using Amkodor.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amkodor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                return _productService.GetAllProducts();
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("search")]
        public async Task<IEnumerable<Product>> Search([FromBody] string value)
        {
            return _productService.Search(value);
        }

        [HttpPost]
        [Route("edit")]
        public void Edit(Product product)
        {
            try
            {
                _productService.Edit(product);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("delete")]
        public void Delete(Product product)
        {
            try
            {
                _productService.Delete(product);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
