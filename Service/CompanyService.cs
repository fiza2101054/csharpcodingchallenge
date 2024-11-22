using Careerhubcoding.Model;
using Careerhubcoding.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Careerhubcoding.Service
{
    internal class CompanyService : ICompanyService
    {
        private readonly CompanyRepository _companyRepository;

        public CompanyService()
        {
            _companyRepository = new CompanyRepository();
        }

    
        public void GetCompanies()
        {
            List<Company> companies = _companyRepository.GetCompanies();  

            if (companies.Count == 0)
            {
                Console.WriteLine("No companies found.");
            }
            else
            {
                Console.WriteLine("\n-List of Companies");
                foreach (var company in companies)
                {
                    Console.WriteLine(company); 
                }
            }
        }

        public void InsertCompany(Company company)
        {
            _companyRepository.InsertCompany(company);
            
        }

    }
}
