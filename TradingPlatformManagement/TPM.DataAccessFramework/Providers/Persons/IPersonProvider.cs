using System.Threading.Tasks;

namespace TPM.DataAccessFramework.Providers.Persons
{
    public interface IPersonProvider
    {
        Task<int> GetCustomersCount();
        Task<int> GetProvidersCount();

    }
}
