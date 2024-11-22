using Careerhubcoding.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Careerhubcoding.Repository
{
    internal interface IJobListingRepository
    {
        List<JobListing> GetAllJobListings();
        void InsertJobListing(JobListing job);
    }
}
