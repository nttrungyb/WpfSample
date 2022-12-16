using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary1.Services.Models;

namespace WpfLibrary1.Services
{
    public class GatewayClient
    {
        //private readonly IConfiguration _configuration; 

        private const string _grantType = "client_credentials";
        private const string _clientId = "vbsp_intellect_offline";
        private const string _clientSecret = "vbsp_intellect_offline_secret";

        private string _baseUrl;
        private bool _isExternal;

        public HttpClient httpClient = new HttpClient();

        public GatewayClient(string baseUrl, bool isExternal = true)
        {
           // _configuration = configuration; 
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _baseUrl = baseUrl;
            _isExternal = isExternal;
        }

        public bool SetAccessToken()
        {
            try
            {
                var url = string.Format("{0}/connect/token", "http://10.63.52.51:8000");
                var dict = new Dictionary<string, string>();
                dict.Add("grant_type", _grantType);
                dict.Add("client_id", _clientId);
                dict.Add("client_secret", _clientSecret);
                using (HttpClient ssoClient = new HttpClient())
                {
                    ssoClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = ssoClient.PostAsync(url, new FormUrlEncodedContent(dict)).Result;
                    var stringValue = response.Content.ReadAsStringAsync().Result;
                    var objectValue = JsonConvert.DeserializeObject<AccessToken>(stringValue);
                    if (!string.IsNullOrEmpty(objectValue?.Token))
                    {
                        httpClient.DefaultRequestHeaders.Remove("Authorization");
                        httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", objectValue.Token));
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public GenericResult<string> Ping()
        {
            try
            {
                var response = httpClient.GetAsync($"v1/ping-offline-api").ConfigureAwait(false);
                var x = response.GetAwaiter().GetResult().Content.ReadAsStringAsync();                
                var _result = JsonConvert.DeserializeObject<GenericResult<string>>(x.Result);
                if (_result != null)
                {
                    return _result;
                }
                else
                {
                    return GenericResult<string>.Fail("Data not found");
                }
            }
            catch (Exception ex)
            {
                return GenericResult<string>.Fail(ex.Message);
            }
        }
    }
}
