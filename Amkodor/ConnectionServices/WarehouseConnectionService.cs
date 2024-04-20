using Amkodor.Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.ConnectionServices
{
    public class WarehouseConnectionService
    {
        private const string _uri = "https://localhost:7014/warehouse";

        private readonly HttpClient _httpClient;

        public WarehouseConnectionService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Warehouse>> GetAllWarehouses()
        {
            var response = await _httpClient.GetAsync(_uri);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var warehouses = JsonConvert.DeserializeObject<IEnumerable<Warehouse>>(responseContent);

                return warehouses;
            }

            return null;
        }
    }
}
