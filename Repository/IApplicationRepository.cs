using Careerhubcoding.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Careerhubcoding.Repository
{
    internal interface IApplicationRepository
    {
        List<Application> GetApplicationsForJob(int jobID);
        void InsertApplication(Application application);
    }
}
