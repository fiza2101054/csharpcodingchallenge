using Careerhubcoding.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Careerhubcoding.Repository
{
    internal interface ICompanyRepository
    {
        List<Company> GetCompanies();
        void InsertCompany(Company company);
    }
}
