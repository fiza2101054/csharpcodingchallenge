using Careerhubcoding.Model;
using Careerhubcoding.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Careerhubcoding.Repository
{
    internal class JobListingRepository : IJobListingRepository
    {

        private readonly string connectionString;
        private SqlCommand _cmd;

        public JobListingRepository()
        {
            connectionString = DBConnUtil.GetConnectionString(); 
            _cmd = new SqlCommand();
        }

        public List<JobListing> GetAllJobListings()
        {
            List<JobListing> jobListings = new List<JobListing>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = "select * from jobs";
                    _cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = _cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            jobListings.Add(ExtractJobListing(reader));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return jobListings;
        }



        public void InsertJobListing(JobListing job)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = @"insert into Jobs 
                                         (CompanyId, JobTitle, JobDescription, JobLocation, Salary, JobType, PostedDate) 
                                         values
                                         (@CompanyId, @JobTitle, @JobDescription, @JobLocation, @Salary, @JobType, @PostedDate)";
                    _cmd.Connection = conn;

                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@CompanyId", job.CompanyID);
                    _cmd.Parameters.AddWithValue("@JobTitle", job.JobTitle);
                    _cmd.Parameters.AddWithValue("@JobDescription", string.IsNullOrEmpty(job.JobDescription) ? DBNull.Value : (object)job.JobDescription);
                    _cmd.Parameters.AddWithValue("@JobLocation", job.JobLocation);
                    _cmd.Parameters.AddWithValue("@Salary", job.Salary);
                    _cmd.Parameters.AddWithValue("@JobType", job.JobType);
                    _cmd.Parameters.AddWithValue("@PostedDate", job.PostedDate);

                    conn.Open();
                    _cmd.ExecuteNonQuery();
                    Console.WriteLine("Job listing added successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding job listing: {ex.Message}");
                }
            }
        }

     
        private JobListing ExtractJobListing(SqlDataReader reader)
        {
            return new JobListing
            {
                JobID = (int)reader["JobId"],
                CompanyID = (int)reader["CompanyId"],
                JobTitle = reader["jobtitle"].ToString(),
                JobDescription = reader["jobdescription"] == DBNull.Value ? null : reader["jobdescription"].ToString(),
                JobLocation = reader["joblocation"].ToString(),
                Salary = (decimal)reader["salary"],
                JobType = reader["jobtype"].ToString(),
                PostedDate = (DateTime)reader["posteddate"]
            };
        }


    }
}
