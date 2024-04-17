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
    }
}
