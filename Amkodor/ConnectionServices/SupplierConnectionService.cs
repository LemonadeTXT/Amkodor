using Amkodor.Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.ConnectionServices
{
    public class SupplierConnectionService
    {
        private const string _uri = "https://localhost:7014/supplier";

        private readonly HttpClient _httpClient;

        public SupplierConnectionService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            var response = await _httpClient.GetAsync(_uri);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var suppliers = JsonConvert.DeserializeObject<IEnumerable<Supplier>>(responseContent);

                return suppliers;
            }

            return null;
        }

        public async void Add(Supplier supplier)
        {
            var supplierSerialize = JsonConvert.SerializeObject(supplier);

            var content = new StringContent(supplierSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/add", content);
        }

        public async void Edit(Supplier supplier)
        {
            var supplierSerialize = JsonConvert.SerializeObject(supplier);

            var content = new StringContent(supplierSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/edit", content);
        }

        public async void Delete(Supplier supplier)
        {
            var supplierSerialize = JsonConvert.SerializeObject(supplier);

            var content = new StringContent(supplierSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/delete", content);
        }
    }
}
