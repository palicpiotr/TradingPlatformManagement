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

        public async Task CreatePerson(PersonViewModel model)
        {
            try
            {
                var countryEntity = new Country
                {
                    ISO = model.Country.ISO,
                    Name = model.Country.Name
                };
                _edmx.Countries.Add(countryEntity);
                await _edmx.SaveChangesAsync();
                var companyEntity = new Company
                {
                    Name = model.Company.Name,
                    AkkreditationDate = model.Company.AkkreditationDate,
                    FoundationDate = model.Company.FoundationDate,
                    INN = model.Company.INN,
                    KPP = model.Company.KPP,
                    OGRN = model.Company.OGRN
                };
                _edmx.Companies.Add(companyEntity);
                await _edmx.SaveChangesAsync();
                var personEntity = new Person
                {
                    CompanyId = companyEntity.CompanyId,
                    CountryId = countryEntity.CountryId,
                    UserId = model.Token,
                    Name = model.Name,
                    SurnamName = model.LastName,
                    Patron = model.Patron,
                    PersonTypeId = model.PersonTypeId,
                };
                _edmx.Persons.Add(personEntity);
                await _edmx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
