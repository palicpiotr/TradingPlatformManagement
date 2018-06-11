using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPM.DataAccessFramework.Models;

namespace TPM.DataAccessFramework.Providers.Biddings
{
    public interface IBiddingProvider
    {
        Task<IEnumerable<BiddingViewModel>> GetBiddings(int typeId);
        Task<IEnumerable<BiddingViewModel>> GetGovBiddings();
        Task<IEnumerable<BiddingViewModel>> GetComBiddings();
        Task<IEnumerable<BiddingViewModel>> GetAgrBiddings();
        Task<IEnumerable<BiddingViewModel>> GetCapBiddings();
        Task<IEnumerable<BiddingViewModel>> GetCorBiddings();
        Task<IEnumerable<BiddingViewModel>> GetImmutBiddings();
    }
}
