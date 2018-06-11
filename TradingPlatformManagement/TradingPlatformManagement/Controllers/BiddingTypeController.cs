using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TPM.DataAccessFramework.Providers.BiddingTypes;

namespace TradingPlatformManagement.Controllers
{
    public class BiddingTypeController : Controller
    {

        private readonly IBiddingTypesProvider _biddingType;

        public BiddingTypeController(IBiddingTypesProvider biddingType)
        {
            _biddingType = biddingType;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetBiddingTypes()
        {
            var biddingTypes = await _biddingType.GetBiddingTypes();
            return Json(biddingTypes, JsonRequestBehavior.AllowGet);
        }

    }
}