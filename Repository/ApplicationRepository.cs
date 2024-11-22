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
    internal class ApplicationRepository : IApplicationRepository
    {
        private readonly string connectionString;
        private readonly SqlCommand _cmd;

        public ApplicationRepository()
        {
            connectionString = DBConnUtil.GetConnectionString();
            _cmd = new SqlCommand();
        }


        public List<Application> GetApplicationsForJob(int jobID)
        {
            List<Application> applications = new List<Application>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {

                    _cmd.CommandText = @"select * from 
                                         from Applications 
                                         where JobID = @JobID";

                    _cmd.Connection = conn;

                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@JobID", jobID);

                    conn.Open();

                    using (SqlDataReader reader = _cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            applications.Add(ExtractApplication(reader));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving applications for Job ID {jobID}: {ex.Message}");
                }
            }

            return applications;
        }


        public void InsertApplication(Application application)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {

                    string query = @"INSERT INTO Applications (JobID, ApplicantID, ApplicationDate, CoverLetter)
                                     VALUES (@JobID, @ApplicantID, @ApplicationDate, @CoverLetter)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@JobID", application.JobID);
                        cmd.Parameters.AddWithValue("@ApplicantID", application.ApplicantID);
                        cmd.Parameters.AddWithValue("@ApplicationDate", application.ApplicationDate);
                        cmd.Parameters.AddWithValue("@CoverLetter",
                            string.IsNullOrEmpty(application.CoverLetter) ? (object)DBNull.Value : application.CoverLetter);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }

                    Console.WriteLine("Job application inserted successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting job application: {ex.Message}");
                }
            }
        }

        private Application ExtractApplication(SqlDataReader reader)
        {
            return new Application
            {
                ApplicationID = (int)reader["ApplicationID"],
                JobID = (int)reader["JobID"],
                ApplicantID = (int)reader["ApplicantID"],
                ApplicationDate = (DateTime)reader["ApplicationDate"],
                CoverLetter = reader["CoverLetter"] == DBNull.Value ? null : reader["CoverLetter"].ToString()
            };
        }

    }
}