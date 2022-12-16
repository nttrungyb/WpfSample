using WpfLibrary1.Services.Services.Implements;
using WpfLibrary1.Services.Services.Interfaces;

namespace WpfLibrary1.Services.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //GatewayClient gatewayClient = new GatewayClient("http://10.63.52.51:8001/" , false);
            //var result = gatewayClient.Ping();
            //Assert.IsNotNull(result);   

            IBODServices _bodServices = new BODServices();

            var data = _bodServices.GetPosInfoList("25");

            if (data != null)
            {
                for(int i = 0; i < data.Result.Count; i++)
                {
                    System.Console.WriteLine($"{data.Result[i].PosCode} - {data.Result[i].PosName} - {data.Result[i].Address}");
                }
            }
        }
    }
}