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
    public class AgriculturalController : Controller
    {

        private IBiddingProvider _biddingProvider;

        public AgriculturalController(IBiddingProvider biddingProvider)
        {
            _biddingProvider = biddingProvider;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetBiddings([DataSourceRequest] DataSourceRequest request, int typeId)
        {
            var biddings = await _biddingProvider.GetAgrBiddings();
            return Json(biddings.ToDataSourceResult(request));
        }

    }
}