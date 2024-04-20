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
    }
}
