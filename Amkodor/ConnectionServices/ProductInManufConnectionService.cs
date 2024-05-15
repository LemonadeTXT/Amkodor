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
    public class ProductInManufConnectionService
    {
        private const string _uri = "https://localhost:7014/productInManuf";

        private readonly HttpClient _httpClient;

        public ProductInManufConnectionService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<ProductInManufacturing>> GetAllProductsInManufacturing()
        {
            var response = await _httpClient.GetAsync(_uri + "/getAllProductsInManufacturing");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var productsInManuf = JsonConvert.DeserializeObject<IEnumerable<ProductInManufacturing>>(responseContent);

                return productsInManuf;
            }

            return null;
        }

        public async Task<IEnumerable<ProductInManufacturing>> GetAllActiveProductsInManufacturing()
        {
            var response = await _httpClient.GetAsync(_uri + "/getAllActiveProductsInManufacturing");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var productsInManuf = JsonConvert.DeserializeObject<IEnumerable<ProductInManufacturing>>(responseContent);

                return productsInManuf;
            }

            return null;
        }

        public async Task<IEnumerable<ProductInManufacturing>> GetAllInactiveProductsInManufacturing()
        {
            var response = await _httpClient.GetAsync(_uri + "/getAllInactiveProductsInManufacturing");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var productsInManuf = JsonConvert.DeserializeObject<IEnumerable<ProductInManufacturing>>(responseContent);

                return productsInManuf;
            }

            return null;
        }

        public async Task<ProductInManufacturing> GetInactiveProdInManufById(int id)
        {
            var valueSerialize = JsonConvert.SerializeObject(id);

            var content = new StringContent(valueSerialize, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_uri + "/getInactiveProdInManufById", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var foundedProductInManuf = JsonConvert.DeserializeObject<ProductInManufacturing>(responseContent);

                return foundedProductInManuf;
            }

            return null;
        }

        public async void Add(ProductInManufacturing productInManuf)
        {
            var productInManufSerialize = JsonConvert.SerializeObject(productInManuf);

            var content = new StringContent(productInManufSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/add", content);
        }

        public async void Edit(ProductInManufacturing productInManuf)
        {
            var productInManufSerialize = JsonConvert.SerializeObject(productInManuf);

            var content = new StringContent(productInManufSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/edit", content);
        }

        public async void Delete(ProductInManufacturing productInManuf)
        {
            var productInManufSerialize = JsonConvert.SerializeObject(productInManuf);

            var content = new StringContent(productInManufSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/delete", content);
        }
    }
}
