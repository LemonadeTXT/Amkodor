using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.BusinessLogic.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();

        IEnumerable<Employee> Search(string value);

        void Add(Employee employee);

        void Edit(Employee employee);

        void Delete(Employee employee);
    }
}
