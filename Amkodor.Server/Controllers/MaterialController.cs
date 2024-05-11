using Amkodor.BusinessLogic.Interfaces;
using Amkodor.BusinessLogic.Services;
using Amkodor.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amkodor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialController : Controller
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public async Task<IEnumerable<Material>> GetAlMaterials()
        {
            try
            {
                return _materialService.GetAllMaterials();
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("getAllMaterialsByWarehouseId")]
        public async Task<IEnumerable<Material>> GetAllMaterialsByWarehouseId([FromBody] int warehouseId)
        {
            try
            {
                return _materialService.GetAllMaterialsByWarehouseId(warehouseId);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("search")]
        public async Task<IEnumerable<Material>> Search([FromBody] string value)
        {
            return _materialService.Search(value);
        }

        [HttpPost]
        [Route("add")]
        public void Add(Material material)
        {
            try
            {
                _materialService.Add(material);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("edit")]
        public void Edit(Material material)
        {
            try
            {
                _materialService.Edit(material);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("delete")]
        public void Delete(Material material)
        {
            try
            {
                _materialService.Delete(material);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
