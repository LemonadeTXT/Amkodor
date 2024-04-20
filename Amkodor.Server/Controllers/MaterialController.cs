using Amkodor.BusinessLogic.Interfaces;
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
    }
}
