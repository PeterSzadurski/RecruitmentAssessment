using Newegg.Marketplace.SDK.Order.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NewEgg.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> OrderView()
        {
            ApiNewegg apiNewegg = new ApiNewegg();
            GetOrderInformationResponse orders;
            orders = await apiNewegg.CallApi();
            return PartialView("_OrderView", orders.ResponseBody.OrderInfoList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}