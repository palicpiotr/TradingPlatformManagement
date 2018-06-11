using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TPM.DataAccessFramework.Providers.Biddings;

namespace TradingPlatformManagement.Controllers
{
    public class GovernmentController : Controller
    {

        private IBiddingProvider _biddingProvider;

        public GovernmentController(IBiddingProvider biddingProvider)
        {
            _biddingProvider = biddingProvider;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetBiddings([DataSourceRequest] DataSourceRequest request, int typeId)
        {
            var biddings = await _biddingProvider.GetGovBiddings();
            return Json(biddings.ToDataSourceResult(request));
        }

    }
}