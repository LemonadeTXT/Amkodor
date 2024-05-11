using Amkodor.BusinessLogic.Interfaces;
using Amkodor.BusinessLogic.Services;
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

        [HttpPost]
        [Route("add")]
        public void Add(Supplier supplier)
        {
            try
            {
                _supplierService.Add(supplier);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("edit")]
        public void Edit(Supplier supplier)
        {
            try
            {
                _supplierService.Edit(supplier);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("delete")]
        public void Delete(Supplier supplier)
        {
            try
            {
                _supplierService.Delete(supplier);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
