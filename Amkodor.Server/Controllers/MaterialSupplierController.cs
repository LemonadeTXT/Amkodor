using Amkodor.BusinessLogic.Interfaces;
using Amkodor.BusinessLogic.Services;
using Amkodor.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amkodor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialSupplierController : Controller
    {
        private readonly IMaterialSupplierService _materialSupplierService;

        public MaterialSupplierController(IMaterialSupplierService materialSupplierService)
        {
            _materialSupplierService = materialSupplierService;
        }

        [HttpGet]
        public async Task<IEnumerable<MaterialSupplier>> GetAllMaterialsSuppliers()
        {
            try
            {
                return _materialSupplierService.GetAllMaterialsSuppliers();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
