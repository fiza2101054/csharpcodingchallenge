using Careerhubcoding.Model;
using Careerhubcoding.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Careerhubcoding.Service
{
    internal class ApplicantService : IApplicantService
    {
        private readonly ApplicantRepository _applicantRepository;

        public ApplicantService()
        {
            _applicantRepository = new ApplicantRepository();
        }

        public void GetApplicants()
        {
            List<Applicant> applicants = _applicantRepository.GetApplicants();

            if (applicants.Count == 0)
            {
                Console.WriteLine("No applicants found in the database.");
            }
            else
            {
                Console.WriteLine("Applicants:");
                foreach (var applicant in applicants)
                {
                    Console.WriteLine(applicant.ToString());
                }
            }
        }


        public void InsertApplicant(Applicant applicant)
        {
           
                _applicantRepository.InsertApplicant(applicant);
                Console.WriteLine("Applicant has been successfully inserted");
            
       
        }
    }
}
