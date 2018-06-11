using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Threading.Tasks;
using System.Web.Mvc;
using TPM.DataAccessFramework.Providers.Biddings;

namespace TradingPlatformManagement.Controllers
{
    public class BiddingController : Controller
    {

        private IBiddingProvider _biddingProvider;

        public BiddingController(IBiddingProvider biddingProvider)
        {
            _biddingProvider = biddingProvider;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetBiddings([DataSourceRequest] DataSourceRequest request, int typeId)
        {
            var biddings = await _biddingProvider.GetBiddings(typeId);
            return Json(biddings.ToDataSourceResult(request));
        }

    }
}