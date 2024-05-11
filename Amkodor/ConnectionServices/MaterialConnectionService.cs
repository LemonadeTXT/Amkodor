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
    public class MaterialConnectionService
    {
        private const string _uri = "https://localhost:7014/material";

        private readonly HttpClient _httpClient;

        public MaterialConnectionService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Material>> GetAllMaterials()
        {
            var response = await _httpClient.GetAsync(_uri);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var materials = JsonConvert.DeserializeObject<IEnumerable<Material>>(responseContent);

                return materials;
            }

            return null;
        }

        public async Task<IEnumerable<Material>> GetAllMaterialsByWarehouseId(int warehouseId)
        {
            var valueSerialize = JsonConvert.SerializeObject(warehouseId);

            var content = new StringContent(valueSerialize, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_uri + "/getAllMaterialsByWarehouseId", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var materials = JsonConvert.DeserializeObject<IEnumerable<Material>>(responseContent);

                return materials;
            }

            return null;
        }

        public async Task<IEnumerable<Material>> Search(string value)
        {
            var valueSerialize = JsonConvert.SerializeObject(value);

            var content = new StringContent(valueSerialize, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_uri + "/search", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var foundedMaterials = JsonConvert.DeserializeObject<IEnumerable<Material>>(responseContent);

                return foundedMaterials;
            }

            return null;
        }

        public async void Add(Material material)
        {
            var materialSerialize = JsonConvert.SerializeObject(material);

            var content = new StringContent(materialSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/add", content);
        }

        public async void Edit(Material material)
        {
            var materialSerialize = JsonConvert.SerializeObject(material);

            var content = new StringContent(materialSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/edit", content);
        }

        public async void Delete(Material material)
        {
            var materialSerialize = JsonConvert.SerializeObject(material);

            var content = new StringContent(materialSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/delete", content);
        }
    }
}
