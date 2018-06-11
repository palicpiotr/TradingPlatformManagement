using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TPM.DataAccessFramework.Models;
using TPM.DataModel.Models;

namespace TPM.DataAccessFramework.Providers.BiddingTypes
{
    public class BiddingTypesProvider : IBiddingTypesProvider
    {

        private readonly TradingPlatformManagementEntities _edmx;

        public BiddingTypesProvider(TradingPlatformManagementEntities edmx)
        {
            _edmx = edmx;
        }

        public async Task<IEnumerable<BiddingTypeViewModel>> GetBiddingTypes() =>
            await (from bt in _edmx.BiddingTypes
                   select new BiddingTypeViewModel
                   {
                       BiddingTypeId = bt.BiddingTypeId,
                       Name = bt.Name
                   })
            .ToListAsync();

    }
}
