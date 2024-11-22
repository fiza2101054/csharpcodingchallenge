using Careerhubcoding.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Careerhubcoding.Service
{
    internal interface ICompanyService
    {
        void GetCompanies();
        void InsertCompany(Company company);
    }
}
