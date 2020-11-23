using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Xml;
using System.Xml.Serialization;

namespace CanadaPost
{
    public class CanadaPostApi
    {
        private string Username = "6e93d53968881714";
        private string Password = "0bfa9fcb9853d1f51ee57a";
        private string xml = @"<mailing-scenario xmlns=""http://www.canadapost.ca/ws/ship/rate-v4"">
<customer-number>2004381</customer-number>
<parcel-characteristics>
<weight>1</weight>
</parcel-characteristics>
<origin-postal-code>K2B8J6</origin-postal-code>
<destination>
<domestic>
<postal-code>J0E1X0</postal-code>
</domestic>
</destination>
</mailing-scenario>";
        public async Task<pricequotesPricequote[]> GetRatings()
        {
            string url = @"https://ct.soa-gw.canadapost.ca/rs/ship/price";
            ApiHandler.ApiClient.DefaultRequestHeaders.Clear();
            string authString = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(Username + ":" + Password));
            ApiHandler.ApiClient.DefaultRequestHeaders.Add("Authorization", authString);
            ApiHandler.ApiClient.DefaultRequestHeaders.Add("Accept-Language", "en-CA");
            ApiHandler.ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.cpc.ship.rate-v4+xml"));
            StringContent content = new StringContent(xml, System.Text.Encoding.Default, "application/vnd.cpc.ship.rate-v4+xml");
            using (HttpResponseMessage response = await ApiHandler.ApiClient.PostAsync(url, content))
            {

                if (response.IsSuccessStatusCode)
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(pricequotes));
                    System.IO.StreamReader reader = new System.IO.StreamReader(await response.Content.ReadAsStreamAsync());
                    pricequotes priceQuotes = (pricequotes)xmlSerializer.Deserialize(reader);
                    reader.Close();
                    return priceQuotes.pricequote;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}