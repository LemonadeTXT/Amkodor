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
    public class RequestMaterialSupConnectionService
    {
        private const string _uri = "https://localhost:7014/requestMaterialSup";

        private readonly HttpClient _httpClient;

        public RequestMaterialSupConnectionService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<RequestMaterialSupplier>> GetAllRequestMaterialsSups()
        {
            var response = await _httpClient.GetAsync(_uri);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var requestMaterialsSuppliers = JsonConvert.DeserializeObject<IEnumerable<RequestMaterialSupplier>>(responseContent);

                return requestMaterialsSuppliers;
            }

            return null;
        }

        public async Task<IEnumerable<RequestMaterialSupplier>> Search(string value)
        {
            var valueSerialize = JsonConvert.SerializeObject(value);

            var content = new StringContent(valueSerialize, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_uri + "/search", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var foundedMaterialsSups = JsonConvert.DeserializeObject<IEnumerable<RequestMaterialSupplier>>(responseContent);

                return foundedMaterialsSups;
            }

            return null;
        }

        public async void Add(RequestMaterialSupplier requestMaterialSupplier)
        {
            var requestMaterialSupplierSerialize = JsonConvert.SerializeObject(requestMaterialSupplier);

            var content = new StringContent(requestMaterialSupplierSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/add", content);
        }

        public async void Edit(RequestMaterialSupplier requestMaterialSupplier)
        {
            var requestMaterialSupplierSerialize = JsonConvert.SerializeObject(requestMaterialSupplier);

            var content = new StringContent(requestMaterialSupplierSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/edit", content);
        }

        public async void Delete(RequestMaterialSupplier requestMaterialSupplier)
        {
            var requestMaterialSupplierSerialize = JsonConvert.SerializeObject(requestMaterialSupplier);

            var content = new StringContent(requestMaterialSupplierSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/delete", content);
        }
    }
}
