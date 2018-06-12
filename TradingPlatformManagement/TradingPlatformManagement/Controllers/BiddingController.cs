using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TPM.DataAccessFramework.Models;
using TPM.DataAccessFramework.Providers.Biddings;
using TPM.DataModel.Models;

namespace TradingPlatformManagement.Controllers
{
    public class BiddingController : Controller
    {

        private IBiddingProvider _biddingProvider;
        private readonly TradingPlatformManagementEntities _edmx;

        public BiddingController(IBiddingProvider biddingProvider, TradingPlatformManagementEntities edmx)
        {
            _biddingProvider = biddingProvider;
            _edmx = edmx;
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

        public async Task<ActionResult> CreateBidding([DataSourceRequest]DataSourceRequest request, BiddingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userID = User.Identity.GetUserId();
                var person = _edmx.Persons.FirstOrDefault(x => x.UserId == userID);
                model.Person.PersonId = person.PersonId;
                var biddingId = await _biddingProvider.CreateBidding(model);
                var bidding = (await _biddingProvider.GetBiddings(-1)).FirstOrDefault(x => x.BiddingId == biddingId);
                model = bidding;
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

    }
}