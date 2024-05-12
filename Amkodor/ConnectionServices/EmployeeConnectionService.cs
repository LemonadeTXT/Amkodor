using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Amkodor.Models.Models;

namespace Amkodor.ConnectionServices
{
    public class EmployeeConnectionService
    {
        private const string _uri = "https://localhost:7014/employee";

        private readonly HttpClient _httpClient;

        public EmployeeConnectionService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var response = await _httpClient.GetAsync(_uri);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var employees = JsonConvert.DeserializeObject<IEnumerable<Employee>>(responseContent);

                return employees;
            }

            return null;
        }

        public async Task<IEnumerable<Employee>> Search(string value)
        {
            var valueSerialize = JsonConvert.SerializeObject(value);

            var content = new StringContent(valueSerialize, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_uri + "/search", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var foundedEmployees = JsonConvert.DeserializeObject<IEnumerable<Employee>>(responseContent);

                return foundedEmployees;
            }

            return null;
        }

        public async void Add(Employee employee)
        {
            var employeeSerialize = JsonConvert.SerializeObject(employee);

            var content = new StringContent(employeeSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/add", content);
        }

        public async void Edit(Employee employee)
        {
            var employeeSerialize = JsonConvert.SerializeObject(employee);

            var content = new StringContent(employeeSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/edit", content);
        }

        public async void Delete(Employee employee)
        {
            var employeeSerialize = JsonConvert.SerializeObject(employee);

            var content = new StringContent(employeeSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/delete", content);
        }
    }
}
