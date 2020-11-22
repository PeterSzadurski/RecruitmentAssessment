using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CanadaPost.Models
{
    public class PriceQuote
    {
        [XmlAttribute("service-name")]
        public string ServiceName { get; set; }
        [XmlAttribute("price-details")]
        public PriceDetails PriceDetail { get; set; }

    }

    public class PriceDetails
    {
        [XmlAttribute("due")]
        public decimal Due { get; set; }
    }

    public class ResultModel
    {
        [XmlAttribute("price-qoutes")]
        public PriceQuote[] PriceQuotes { get; set; }

    }
}