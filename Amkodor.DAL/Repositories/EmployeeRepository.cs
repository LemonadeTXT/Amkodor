using Amkodor.DAL.Interfaces;
using Amkodor.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext _applicationContext;

        public EmployeeRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            var employees = _applicationContext.Employees.Include(e => e.ProductsInManufacturing).ToList();

            return employees;
        }

        public IEnumerable<Employee> Search(string value)
        {
            var foundEmployees = new List<Employee>();

            value = value.Trim().ToLower();

            var employees = _applicationContext.Employees.AsQueryable();

            foreach (var employee in employees)
            {
                if (employee.Id.ToString().Contains(value) ||
                    employee.FullName.ToLower().Contains(value) ||
                    employee.PhoneNumber.ToLower().Contains(value) ||
                    employee.Position.Value.ToString().ToLower().Contains(value))
                {
                    foundEmployees.Add(employee);
                }
            }

            return foundEmployees;
        }

        public void Add(Employee employee)
        {
            _applicationContext.Employees.Add(employee);
            _applicationContext.SaveChanges();
        }

        public void Edit(Employee employee)
        {
            _applicationContext.Employees.Update(employee);
            _applicationContext.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            _applicationContext.Employees.Remove(employee);
            _applicationContext.SaveChanges();
        }
    }
}
