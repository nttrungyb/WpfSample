using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary1.Services.Models;
using WpfLibrary1.Services.Services.Interfaces;

namespace WpfLibrary1.Services.Services.Implements
{
    public class BODServices : IBODServices
    {
        GatewayClient _gatewayClient = new GatewayClient("http://10.63.52.51:8001/api/", false);

        public GenericResult<List<PosInfoViewModel>> GetPosInfoList(string branchCode)
        {
            var _pingResult = _gatewayClient.Ping();
            if (_pingResult != null && _pingResult.IsSuccess)
            {
                _gatewayClient.SetAccessToken();

                var url = $"v1/pos-info?branchCode={branchCode}";
                var response = _gatewayClient.httpClient.GetAsync(url).ConfigureAwait(false);

                var x = response.GetAwaiter().GetResult().Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var _result = JsonConvert.DeserializeObject<GenericResult<List<PosInfoViewModel>>>(x.Result, settings);
                if (_result != null)
                {
                    return _result;
                }
                else
                {
                    return GenericResult<List<PosInfoViewModel>>.Fail("No data");
                }
            }
            else
            {
                return GenericResult<List<PosInfoViewModel>>.Fail("No connect");
            }
            
        }
    }
}
