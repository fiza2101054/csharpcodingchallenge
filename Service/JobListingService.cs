using Careerhubcoding.Model;
using Careerhubcoding.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Careerhubcoding.Service
{
    internal class JobListingService : IJobListingService
    {

        private readonly JobListingRepository _jobListingRepository;

        public JobListingService()
        {
            _jobListingRepository = new JobListingRepository();
        }

        public void GetAllJobListings()
        {
            List<JobListing> jobListings = _jobListingRepository.GetAllJobListings();

            if (jobListings.Count == 0)
            {
                Console.WriteLine("No job listings found in the database.");
            }
            else
            {
                Console.WriteLine("Job Listings:");
                foreach (var job in jobListings)
                {
                    Console.WriteLine($"Job ID: {job.JobID}, Title: {job.JobTitle}, Location: {job.JobLocation}, Salary: {job.Salary:C}, Type: {job.JobType}, Posted Date: {job.PostedDate:yyyy-MM-dd}");
                }
            }
        }

        public void InsertJobListing(JobListing job)
        { 
                _jobListingRepository.InsertJobListing(job);
                Console.WriteLine("Job listing has been successfully inserted through the service layer.");

            }
           
        }
    }

