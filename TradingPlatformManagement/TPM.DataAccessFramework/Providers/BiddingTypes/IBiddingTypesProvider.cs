using System.Collections.Generic;
using System.Threading.Tasks;
using TPM.DataAccessFramework.Models;

namespace TPM.DataAccessFramework.Providers.BiddingTypes
{
    public interface IBiddingTypesProvider
    {
        Task<IEnumerable<BiddingTypeViewModel>> GetBiddingTypes();

    }
}
