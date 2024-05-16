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
    public class ProductConnectionService
    {
        private const string _uri = "https://localhost:7014/product";

        private readonly HttpClient _httpClient;

        public ProductConnectionService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var response = await _httpClient.GetAsync(_uri);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(responseContent);

                return products;
            }

            return null;
        }

        public async Task<IEnumerable<Product>> Search(string value)
        {
            var valueSerialize = JsonConvert.SerializeObject(value);

            var content = new StringContent(valueSerialize, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_uri + "/search", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var foundedProducts = JsonConvert.DeserializeObject<IEnumerable<Product>>(responseContent);

                return foundedProducts;
            }

            return null;
        }

        public async void Add(Product product)
        {
            var productSerialize = JsonConvert.SerializeObject(product);

            var content = new StringContent(productSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/add", content);
        }

        public async void Edit(Product product)
        {
            var productSerialize = JsonConvert.SerializeObject(product);

            var content = new StringContent(productSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/edit", content);
        }

        public async void Delete(Product product)
        {
            var productSerialize = JsonConvert.SerializeObject(product);

            var content = new StringContent(productSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/delete", content);
        }
    }
}
