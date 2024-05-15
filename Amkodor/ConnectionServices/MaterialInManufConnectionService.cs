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
    public class MaterialInManufConnectionService
    {
        private const string _uri = "https://localhost:7014/materialInManuf";

        private readonly HttpClient _httpClient;

        public MaterialInManufConnectionService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<MaterialInManufacturing>> GetAllMaterialsInManufacturing()
        {
            var response = await _httpClient.GetAsync(_uri);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var materialsInManuf = JsonConvert.DeserializeObject<IEnumerable<MaterialInManufacturing>>(responseContent);

                return materialsInManuf;
            }

            return null;
        }

        public async Task<IEnumerable<MaterialInManufacturing>> Search(string value)
        {
            var valueSerialize = JsonConvert.SerializeObject(value);

            var content = new StringContent(valueSerialize, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_uri + "/search", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var foundedMaterialsInManuf = JsonConvert.DeserializeObject<IEnumerable<MaterialInManufacturing>>(responseContent);

                return foundedMaterialsInManuf;
            }

            return null;
        }

        public async void Add(MaterialInManufacturing materialInManufacturing)
        {
            var materialInManufSerialize = JsonConvert.SerializeObject(materialInManufacturing);

            var content = new StringContent(materialInManufSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/add", content);
        }

        public async void Edit(MaterialInManufacturing materialInManufacturing)
        {
            var materialInManufSerialize = JsonConvert.SerializeObject(materialInManufacturing);

            var content = new StringContent(materialInManufSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/edit", content);
        }

        public async void Delete(MaterialInManufacturing materialInManufacturing)
        {
            var materialInManufSerialize = JsonConvert.SerializeObject(materialInManufacturing);

            var content = new StringContent(materialInManufSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/delete", content);
        }
    }
}
