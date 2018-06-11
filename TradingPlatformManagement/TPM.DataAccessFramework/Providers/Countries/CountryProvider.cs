using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPM.DataAccessFramework.Models;
using TPM.DataModel.Models;

namespace TPM.DataAccessFramework.Providers.Countries
{
    public class CountryProvider : ICountryProvider
    {
        private readonly TradingPlatformManagementEntities _edmx;

        public CountryProvider(TradingPlatformManagementEntities edmx)
        {
            _edmx = edmx;
        }

        public async Task<IEnumerable<CountryViewModel>> GetCountries() =>
             await (from c in _edmx.Countries
                    select new CountryViewModel
                    {
                        CountryId = c.CountryId,
                        Name = c.Name,
                        ISO = c.ISO
                    })
             .ToListAsync();
       

    }
}
