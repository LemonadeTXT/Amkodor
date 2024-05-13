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

        [HttpPost]
        [Route("getAllMaterialsSupBySupplierId")]
        public async Task<IEnumerable<MaterialSupplier>> GetAllMaterialsSupBySupplierId([FromBody] int supplierId)
        {
            try
            {
                return _materialSupplierService.GetAllMaterialsSupBySupplierId(supplierId);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("search")]
        public async Task<IEnumerable<MaterialSupplier>> Search([FromBody] string value)
        {
            return _materialSupplierService.Search(value);
        }

        [HttpPost]
        [Route("add")]
        public void Add(MaterialSupplier materialSupplier)
        {
            try
            {
                _materialSupplierService.Add(materialSupplier);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("edit")]
        public void Edit(MaterialSupplier materialSupplier)
        {
            try
            {
                _materialSupplierService.Edit(materialSupplier);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("delete")]
        public void Delete(MaterialSupplier materialSupplier)
        {
            try
            {
                _materialSupplierService.Delete(materialSupplier);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
