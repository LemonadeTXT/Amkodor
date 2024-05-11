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
    public class MaterialSupplierConnectionService
    {
        private const string _uri = "https://localhost:7014/materialSupplier";

        private readonly HttpClient _httpClient;

        public MaterialSupplierConnectionService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<MaterialSupplier>> GetAllMaterialsSuppliers()
        {
            var response = await _httpClient.GetAsync(_uri);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var materialsSuppliers = JsonConvert.DeserializeObject<IEnumerable<MaterialSupplier>>(responseContent);

                return materialsSuppliers;
            }

            return null;
        }

        public async Task<IEnumerable<MaterialSupplier>> GetAllMaterialsSupBySupplierId(int supplierId)
        {
            var valueSerialize = JsonConvert.SerializeObject(supplierId);

            var content = new StringContent(valueSerialize, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_uri + "/getAllMaterialsSupBySupplierId", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var materialsSuppliers = JsonConvert.DeserializeObject<IEnumerable<MaterialSupplier>>(responseContent);

                return materialsSuppliers;
            }

            return null;
        }
    }
}
