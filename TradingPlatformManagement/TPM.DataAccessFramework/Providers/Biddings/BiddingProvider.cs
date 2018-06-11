using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPM.DataAccessFramework.Models;
using TPM.DataModel.Models;

namespace TPM.DataAccessFramework.Providers.Biddings
{
    public class BiddingProvider : IBiddingProvider
    {
        private readonly TradingPlatformManagementEntities _edmx;

        public BiddingProvider(TradingPlatformManagementEntities edmx)
        {
            _edmx = edmx;
        }

        public async Task<IEnumerable<BiddingViewModel>> GetBiddings(int typeId)
        {
            var biddings = await (from bidding in _edmx.Biddings
                                  select new BiddingViewModel
                                  {
                                      BiddingId = bidding.BiddingId,
                                      Name = bidding.Name,
                                      BiddingType = new BiddingTypeViewModel
                                      {
                                          BiddingTypeId = bidding.BiddingType.BiddingTypeId,
                                          Name = bidding.BiddingType.Name
                                      },
                                      Person = new PersonViewModel
                                      {
                                          PersonId = bidding.Person.PersonId,
                                          Name = bidding.Person.Name,
                                          LastName = bidding.Person.SurnamName,
                                          Patron = bidding.Person.Patron
                                      },
                                      TenderType = new TenderTypeViewModel
                                      {
                                          TenderTypeId = bidding.TenderTypeId,
                                          Name = bidding.TenderType.Name
                                      },
                                      Country = new CountryViewModel
                                      {
                                          CountryId = bidding.Country.CountryId,
                                          Name = bidding.Country.Name,
                                          ISO = bidding.Country.ISO.ToLower()
                                      }
                                  }).ToListAsync();
            if (typeId > 0)
                biddings = biddings.Where(x => x.BiddingType.BiddingTypeId == typeId).ToList();
            return biddings;
        }
    }
}
