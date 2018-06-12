using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPM.DataAccessFramework.Models;

namespace TPM.DataAccessFramework.Providers.PersonTypes
{
    public interface IPersonTypesProvider
    {
        Task<IEnumerable<PersonTypeViewModel>> GetPersonTypes();
    }
}
