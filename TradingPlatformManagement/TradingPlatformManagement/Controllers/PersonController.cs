using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TPM.DataAccessFramework.Providers.Persons;

namespace TradingPlatformManagement.Controllers
{
    public class PersonController : Controller
    {

        private IPersonProvider _personProvider;

        public PersonController(IPersonProvider personProvider)
        {
            _personProvider = personProvider;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetCustomersCount()
        {
            var c = await _personProvider.GetCustomersCount();
            ViewBag.Count = c;
            return PartialView("_Customers");
        }

        public async Task<ActionResult> GetProvidersCount()
        {
            var p = await _personProvider.GetProvidersCount();
            return PartialView("Providers", p);
        }

        public ActionResult Providers() => View();

        public ActionResult Customers() => View();

        public async Task<ActionResult> GetProviders([DataSourceRequest]DataSourceRequest request)
        {
            var providers = await _personProvider.GetProviders();
            return Json(providers.ToDataSourceResult(request));
        }

        public async Task<ActionResult> GetCustomers([DataSourceRequest]DataSourceRequest request)
        {
            var customers = await _personProvider.GetCustomers();
            return Json(customers.ToDataSourceResult(request));
        }

    }
}