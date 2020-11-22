using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http.Headers;
using System.Text;
using CanadaPost.Models;
using System.Threading.Tasks;
using System.Net.Http;

namespace CanadaPost
{
    public class CanadaPostApi
    {
        private string Username = "6e93d53968881714";
        private string Password = "0bfa9fcb9853d1f51ee57a";
        public  async Task<ResultModel> GetRatings()
        {
            string url = @"https://ct.soa-gw.canadapost.ca/rs/ship/price";
            ApiHandler.ApiClient.DefaultRequestHeaders.Clear();
            ApiHandler.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Convert.ToBase64String(Encoding.Default.GetBytes(Username + ":" + Password)));
            ApiHandler.ApiClient.DefaultRequestHeaders.Add("Accept-Language", "en-CA");
            ApiHandler.ApiClient.DefaultRequestHeaders.Add("ContentType", "application/vnd.cpc.ship.rate-v4+xml");
            ApiHandler.ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            using (HttpResponseMessage response = await ApiHandler.ApiClient.GetAsync(url))
            {

                if (response.IsSuccessStatusCode)
                {
                    ResultModel priceQuotes = await response.Content.ReadAsAsync<ResultModel>();
                    return priceQuotes;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}