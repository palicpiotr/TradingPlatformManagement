using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TPM.DataAccessFramework.Models;
using TPM.DataModel.Models;

namespace TPM.DataAccessFramework.Providers.Companies
{
    public class CompanyProvider : ICompanyProvider
    {

        private readonly TradingPlatformManagementEntities _edmx;

        public CompanyProvider(TradingPlatformManagementEntities edmx)
        {
            _edmx = edmx;
        }

        public async Task<IEnumerable<CompanyViewModel>> GetCompanies() =>
            await (from c in _edmx.Companies
                   select new CompanyViewModel
                   {
                       CompanyId = c.CompanyId,
                       Name = c.Name,
                       AkkreditationDate = c.AkkreditationDate,
                       FoundationDate = c.FoundationDate,
                       INN = c.INN,
                       KPP = c.KPP,
                       OGRN = c.OGRN
                   })
            .ToListAsync();
       
    }
}
