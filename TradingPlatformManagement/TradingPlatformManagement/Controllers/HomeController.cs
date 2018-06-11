using System.Web.Mvc;

namespace TradingPlatformManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}