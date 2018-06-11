using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPM.DataAccessFramework.Models;

namespace TPM.DataAccessFramework.Providers.Countries
{
    public interface ICountryProvider
    {
        Task<IEnumerable<CountryViewModel>> GetCountries();

    }
}
