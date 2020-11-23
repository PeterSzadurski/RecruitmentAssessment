using System.Threading.Tasks;
using System.Web.Mvc;
namespace CanadaPost.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> RateView()
        {
            CanadaPostApi canadaPost = new CanadaPostApi();
            pricequotesPricequote[] pqs;
            pqs = await canadaPost.GetRatings();

            return PartialView("_RateView", pqs);
        }

    }
}