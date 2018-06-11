using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TPM.DataAccessFramework.Providers.Countries;

namespace TradingPlatformManagement.Controllers
{
    public class CountryController : Controller
    {

        private readonly ICountryProvider _countryProvider;

        public CountryController(ICountryProvider countryProvider)
        {
            _countryProvider = countryProvider;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetCountries()
        {
            var countries = await _countryProvider.GetCountries();
            return Json(countries, JsonRequestBehavior.AllowGet);
        }

    }
}