using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebAPiTest.Models.Moov;

namespace Moov_WebApplication_Project.Services
{
    public class TokenService
    {
             
        private readonly IConfiguration _Config;
      
        public TokenService(IConfiguration configuration)
        {
            _Config = configuration;

        }
        public async Task<string> TokenGen()
        {            
            //token generation
            string apiUrlToken = _Config["TokenParameter:apiUrlTok"];

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrlToken);
                var token = new CreateAccessTokenRequest
                {
                    grant_type = _Config["TokenParameter:grant_type"],
                    client_id = _Config["TokenParameter:client_id"],
                    client_secret = _Config["TokenParameter:client_secret"],
                    scope = _Config["TokenParameter:scope"],
                    refresh_token = _Config["TokenParameter:refresh_token"],
            };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var body = JsonConvert.SerializeObject(token);
                var stringContent = new StringContent(body, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUrlToken, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<CreateAccessTokenResponse>(result);
                    var s = data.access_token;
                    return s;                   
                }
            }
            return null;
        }
        public async Task<string> ScopeToken(string scopes)
        {
            string apiUrlToken = _Config["TokenParameter:apiUrlTok"];
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrlToken);
                var token = new CreateAccessTokenRequest
                {
                    grant_type = _Config["TokenParameter:grant_type"],
                    client_id = _Config["TokenParameter:client_id"],
                    client_secret = _Config["TokenParameter:client_secret"],
                    scope = scopes,
                    refresh_token = "",
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var body = JsonConvert.SerializeObject(token);
                var stringContent = new StringContent(body, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUrlToken, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<CreateAccessTokenResponse>(result);
                    var sc = data.access_token;
                    return sc;
                }
                return null;
            }
        }       
    }
}
