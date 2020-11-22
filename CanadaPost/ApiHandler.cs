using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace CanadaPost
{
    public class ApiHandler
    {
        public static HttpClient ApiClient { get; set; }


        public void InitializeClient()
        {

            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            //ApiClient.DefaultRequestHeaders.Accept.Add();

        }

    }
}