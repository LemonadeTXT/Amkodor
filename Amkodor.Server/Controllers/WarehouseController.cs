using Amkodor.BusinessLogic.Interfaces;
using Amkodor.DAL.Interfaces;
using Amkodor.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amkodor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<IEnumerable<Warehouse>> GetAllWarehouses()
        {
            try
            {
                return _warehouseService.GetAllWarehouses();
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("add")]
        public void Add(Warehouse warehouse)
        {
            try
            {
                _warehouseService.Add(warehouse);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("edit")]
        public void Edit(Warehouse warehouse)
        {
            try
            {
                _warehouseService.Edit(warehouse);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("delete")]
        public void Delete(Warehouse warehouse)
        {
            try
            {
                _warehouseService.Delete(warehouse);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
