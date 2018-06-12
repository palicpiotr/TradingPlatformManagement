using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TPM.DataAccessFramework.Providers.Biddings;

namespace TradingPlatformManagement.Controllers
{
    public class ProviderController : Controller
    {
        private readonly IBiddingProvider _biddingProvider;

        public ProviderController(IBiddingProvider biddingProvider)
        {
            _biddingProvider = biddingProvider;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Confirm(int biddingId)
        {
            var biddings = await _biddingProvider.GetBiddings(-5);
            var currentBidding = biddings.Where(x => x.BiddingId == biddingId).FirstOrDefault();
            return PartialView("_Confirmation", currentBidding);
        }

    }
}