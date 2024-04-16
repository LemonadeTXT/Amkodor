using Amkodor.Common.DTOs;
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
    public class AuthConnectionService
    {
        private const string _uri = "https://localhost:7014/auth";

        private readonly HttpClient _httpClient;

        public AuthConnectionService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> Auth(UserDto userDto)
        {
            var userDtoSerialize = JsonConvert.SerializeObject(userDto);

            var content = new StringContent(userDtoSerialize, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_uri, content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var isAuth = JsonConvert.DeserializeObject<bool>(responseContent);

                return isAuth;
            }

            return false;
        }
    }
}
