using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TPM.DataAccessFramework.Providers.Companies;

namespace TradingPlatformManagement.Controllers
{
    public class CompanyController : Controller
    {

        private readonly ICompanyProvider _companyProvider;

        public CompanyController(ICompanyProvider companyProvider)
        {
            _companyProvider = companyProvider;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetCompanies()
        {
            var companies = await _companyProvider.GetCompanies();
            return Json(companies, JsonRequestBehavior.AllowGet);
        }

    }
}