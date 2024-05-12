using Amkodor.BusinessLogic.Interfaces;
using Amkodor.DAL.Interfaces;
using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }

        public IEnumerable<Employee> Search(string value)
        {
            return _employeeRepository.Search(value);
        }

        public void Add(Employee employee)
        {
            _employeeRepository.Add(employee);
        }

        public void Edit(Employee employee)
        {
            _employeeRepository.Edit(employee);
        }

        public void Delete(Employee employee)
        {
            _employeeRepository.Delete(employee);
        }
    }
}
