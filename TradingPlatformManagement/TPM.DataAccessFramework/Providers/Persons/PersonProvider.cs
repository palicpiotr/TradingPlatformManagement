using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPM.DataModel.Models;

namespace TPM.DataAccessFramework.Providers.Persons
{
    public class PersonProvider : IPersonProvider
    {

        private readonly TradingPlatformManagementEntities _edmx;

        public PersonProvider(TradingPlatformManagementEntities emdx)
        {
            _edmx = emdx;
        }

        public async Task<int> GetCustomersCount() => await _edmx.Persons.Where(x => x.PersonTypeId == 1).CountAsync();

        public async Task<int> GetProvidersCount() => await _edmx.Persons.Where(x => x.PersonTypeId == 2).CountAsync();
    }
}
