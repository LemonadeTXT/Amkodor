using Amkodor.BusinessLogic.Interfaces;
using Amkodor.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amkodor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            try
            {
                return _employeeService.GetAllEmployees();
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("search")]
        public async Task<IEnumerable<Employee>> Search([FromBody] string value)
        {
            return _employeeService.Search(value);
        }

        [HttpPost]
        [Route("add")]
        public void Add(Employee employee)
        {
            try
            {
                _employeeService.Add(employee);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("edit")]
        public void Edit(Employee employee)
        {
            try
            {
                _employeeService.Edit(employee);
            }
            catch
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [Route("delete")]
        public void Delete(Employee employee)
        {
            try
            {
                _employeeService.Delete(employee);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
