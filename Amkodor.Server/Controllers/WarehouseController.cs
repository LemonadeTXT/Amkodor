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
    }
}
