using Newegg.Marketplace.SDK;
using Newegg.Marketplace.SDK.Base;
using Newegg.Marketplace.SDK.Order;
using Newegg.Marketplace.SDK.Order.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace NewEgg
{
    public class ApiNewegg
    {

        private OrderCall orderCall;
        public async Task<GetOrderInformationResponse> CallApi()
        {

            string mockPath = HttpContext.Current.Server.MapPath(@"~/mocks/");
            // fix the formatting
             mockPath = mockPath.Replace(@"\", @"\\");
           
            string jsonString = @"{
  ""SellerID"": ""****"",
  ""Credentials"": {
                ""Authorization"": ""********************************"",
    ""SecretKey"": ""*******-****-****-****-************""
  },
  ""MockPath"": """ + mockPath + @""",
  ""Connection"": {
                ""RequestTimeoutMs"": 5000,
    ""AttemptsTimes"": 5,
    ""RetryIntervalMs"": 1000
  },
  ""APIFormat"": ""XML"",
  ""LogLevel"": ""Debug""
}";
            System.Diagnostics.Debug.WriteLine(jsonString);


            //APIConfig config = APIConfig.FromJsonFile(HttpContext.Current.Server.MapPath(@"~/Newegg.json"));
            APIConfig config = APIConfig.FromJson(jsonString);
            APIClient test = new APIClient(config) { SimulationEnabled = true };
            orderCall = new OrderCall(test);
            var orderReq = new GetOrderInformationRequest(new GetOrderInformationRequestCriteria()
            {
                Status = Newegg.Marketplace.SDK.Order.Model.OrderStatus.Unshipped,
                Type = OrderInfoType.All,
                OrderDateFrom = "2016-01-01 09:30:47",
                OrderDateTo = "2017-12-17 09:30:47",
                OrderDownloaded = 0
            });
            return await orderCall.GetOrderInformation(null, orderReq);

        }
    }
}