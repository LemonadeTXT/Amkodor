using Amkodor.BusinessLogic.Interfaces;
using Amkodor.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amkodor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialInManufController : Controller
    {
        private readonly IMaterialInManufService _materialInManufService;

        public MaterialInManufController(IMaterialInManufService materialInManufService)
        {
            _materialInManufService = materialInManufService;
        }

        [HttpGet]
        public async Task<IEnumerable<MaterialInManufacturing>> GetAllMaterialsInManufacturing()
        {
            try
            {
                return _materialInManufService.GetAllMaterialsInManufacturing();
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("search")]
        public async Task<IEnumerable<MaterialInManufacturing>> Search([FromBody] string value)
        {
            return _materialInManufService.Search(value);
        }

        [HttpPost]
        [Route("add")]
        public void Add(MaterialInManufacturing materialInManufacturing)
        {
            try
            {
                _materialInManufService.Add(materialInManufacturing);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("edit")]
        public void Edit(MaterialInManufacturing materialInManufacturing)
        {
            try
            {
                _materialInManufService.Edit(materialInManufacturing);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("delete")]
        public void Delete(MaterialInManufacturing materialInManufacturing)
        {
            try
            {
                _materialInManufService.Delete(materialInManufacturing);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
