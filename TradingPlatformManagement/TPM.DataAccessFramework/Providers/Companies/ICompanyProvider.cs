using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPM.DataAccessFramework.Models;

namespace TPM.DataAccessFramework.Providers.Companies
{
    public interface ICompanyProvider
    {
        Task<IEnumerable<CompanyViewModel>> GetCompanies();
    }
}
