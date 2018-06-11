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

    }
}