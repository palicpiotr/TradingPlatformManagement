using System.Collections.Generic;
using System.Threading.Tasks;
using TPM.DataAccessFramework.Models;

namespace TPM.DataAccessFramework.Providers.Persons
{
    public interface IPersonProvider
    {
        Task<int> GetCustomersCount();
        Task<int> GetProvidersCount();
        Task<IEnumerable<PersonViewModel>> GetPersons(int typeId);
        Task<IEnumerable<PersonViewModel>> GetCustomers();
        Task<IEnumerable<PersonViewModel>> GetProviders();
    }
}
