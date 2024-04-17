using Amkodor.BusinessLogic.Interfaces;
using Amkodor.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amkodor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            try
            {
                return _supplierService.GetAllSuppliers();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
