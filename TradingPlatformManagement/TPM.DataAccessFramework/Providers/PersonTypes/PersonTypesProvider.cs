using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TPM.DataAccessFramework.Models;
using TPM.DataModel.Models;

namespace TPM.DataAccessFramework.Providers.PersonTypes
{
    public class PersonTypesProvider : IPersonTypesProvider
    {
        private readonly TradingPlatformManagementEntities _edmx;

        public PersonTypesProvider(TradingPlatformManagementEntities emdx)
        {
            _edmx = emdx;
        }

        public async Task<IEnumerable<PersonTypeViewModel>> GetPersonTypes() =>
            await (from pt in _edmx.PersonTypes
                   select new PersonTypeViewModel
                   {
                       PersonTypeId = pt.PersonTypeId,
                       Name = pt.Name
                   })
            .ToListAsync();

    }
}
