using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPM.DataAccessFramework.Models;
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

        public async Task<IEnumerable<PersonViewModel>> GetPersons(int typeId)
        {
            var persons = await (from person in _edmx.Persons
                                 select new PersonViewModel
                                 {
                                     PersonId = person.PersonId,
                                     PersonTypeId = person.PersonTypeId,
                                     Name = person.Name,
                                     LastName = person.SurnamName,
                                     Patron = person.Patron,
                                     Company = new CompanyViewModel
                                     {
                                         CompanyId = person.Company.CompanyId,
                                         Name = person.Company.Name,
                                         INN = person.Company.INN,
                                         AkkreditationDate = person.Company.AkkreditationDate,
                                         FoundationDate = person.Company.FoundationDate,
                                         KPP = person.Company.KPP,
                                         OGRN = person.Company.OGRN
                                     },
                                     Country = new CountryViewModel
                                     {
                                         CountryId = person.Country.CountryId,
                                         ISO = person.Country.ISO.ToLower(),
                                         Name = person.Country.Name
                                     }
                                 }).ToListAsync(); ;

            if (typeId > 0)
                persons = persons.Where(x => x.PersonTypeId == typeId).ToList();
            return persons;
        }

        public async Task<IEnumerable<PersonViewModel>> GetProviders() => await GetPersons(2);

        public async Task<IEnumerable<PersonViewModel>> GetCustomers() => await GetPersons(1);

        public async Task<int> GetProvidersCount() => await _edmx.Persons.Where(x => x.PersonTypeId == 2).CountAsync();
    }
}
