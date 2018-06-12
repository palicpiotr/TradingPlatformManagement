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
                                      },
                                      Company = new CompanyViewModel
                                      {
                                          CompanyId = bidding.Person.Company.CompanyId,
                                          Name = bidding.Person.Company.Name,
                                          AkkreditationDate = bidding.Person.Company.AkkreditationDate,
                                          FoundationDate = bidding.Person.Company.FoundationDate,
                                          INN = bidding.Person.Company.INN,
                                          KPP = bidding.Person.Company.KPP,
                                          OGRN = bidding.Person.Company.OGRN
                                      },
                                      Lot = new LotViewModel
                                      {
                                          LotId = bidding.Lot.LotId,
                                          DateOfBidding = bidding.Lot.DateOfBidding,
                                          DateOfEndRegistration = bidding.Lot.DateOfEndRegistration,
                                          DateOfPub = bidding.Lot.DateOfPub,
                                          DateOfStartRegistration = bidding.Lot.DateOfStartRegistration,
                                          DateOfSummarizing = bidding.Lot.DateOfSummarizing,
                                          DeliveryAddress = bidding.Lot.DeliveryAddress,
                                          Name = bidding.Lot.Name,
                                          Status = bidding.Lot.Status
                                      }
                                  }).ToListAsync();
            if (typeId > 0)
                return biddings.Where(x => x.BiddingType.BiddingTypeId > typeId).ToList();
            return biddings;
        }

        public async Task<IEnumerable<BiddingViewModel>> GetCapBiddings() => await GetBiddings(4);

        public async Task<IEnumerable<BiddingViewModel>> GetComBiddings() => await GetBiddings(2);

        public async Task<IEnumerable<BiddingViewModel>> GetCorBiddings() => await GetBiddings(5);

        public async Task<IEnumerable<BiddingViewModel>> GetGovBiddings() => await GetBiddings(1);

        public async Task<IEnumerable<BiddingViewModel>> GetImmutBiddings() => await GetBiddings(6);

        public async Task<IEnumerable<BiddingViewModel>> GetAgrBiddings() => await GetBiddings(3);

        public async Task<int> CreateBidding(BiddingViewModel model)
        {
            try
            {
                var lotEntity = new Lot
                {
                    Name = model.Lot.Name,
                    Status = 1,
                    DateOfEndRegistration = model.Lot.DateOfEndRegistration,
                    DateOfPub = model.Lot.DateOfPub,
                    DateOfStartRegistration = model.Lot.DateOfStartRegistration,
                    DateOfSummarizing = model.Lot.DateOfSummarizing,
                    DateOfBidding = model.Lot.DateOfBidding,
                    DeliveryAddress = model.Lot.DeliveryAddress
                };
                _edmx.Lots.Add(lotEntity);
                await _edmx.SaveChangesAsync();
                var documentEntity = new Document
                {
                    Name = model.Document.Name,
                    URL = model.Document.URL
                };
                _edmx.Documents.Add(documentEntity);
                await _edmx.SaveChangesAsync();
                var protocolEntity = new Protocol
                {
                    Name = model.Protocol.Name,
                    Description = model.Protocol.Desc
                };
                _edmx.Protocols.Add(protocolEntity);
                await _edmx.SaveChangesAsync();
                var countryEntity = new Country
                {
                    Name = model.Country.Name,
                    ISO = model.Country.ISO
                };
                _edmx.Countries.Add(countryEntity);
                await _edmx.SaveChangesAsync();
                var biddingEntity = new Bidding
                {
                    BiddingTypeId = model.BiddingType.BiddingTypeId,
                    Name = model.Name,
                    LotId = lotEntity.LotId,
                    PersonId = model.Person.PersonId,
                    TenderTypeId = model.TenderType.TenderTypeId,
                    ProtocolId = model.ProtocolId,
                    CountryId = model.Country.CountryId
                };
                _edmx.Biddings.Add(biddingEntity);
                await _edmx.SaveChangesAsync();
                return biddingEntity.BiddingId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
