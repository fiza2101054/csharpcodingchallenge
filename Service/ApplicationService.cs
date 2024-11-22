using Careerhubcoding.Model;
using Careerhubcoding.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Careerhubcoding.Service
{
    internal class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService()
        {
            _applicationRepository = new ApplicationRepository();
        }
        public void GetApplicationsForJob(int jobID)
        {
            List<Application> applications = _applicationRepository.GetApplicationsForJob(jobID);

            if (applications.Count == 0)
            {
                Console.WriteLine($"No applications found for Job ID {jobID}.");
            }
            else
            {
                Console.WriteLine($"\nApplications for Job ID {jobID}:");
                foreach (var application in applications)
                {
                    Console.WriteLine(application);
                }
            }
        }



        public void ApplyForJob(Application application) 
        {
            _applicationRepository.InsertApplication(application);
        }
    }
}
