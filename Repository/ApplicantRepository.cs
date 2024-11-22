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
    internal class ApplicantRepository : IApplicantRepository
    {
        private readonly string connectionString;
        private readonly SqlCommand _cmd;

        public ApplicantRepository()
        {
            connectionString = DBConnUtil.GetConnectionString();
            _cmd = new SqlCommand();
        }

        public List<Applicant> GetApplicants()
        {
            List<Applicant> applicants = new List<Applicant>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = "select* from Applicants";
                    _cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = _cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            applicants.Add(ExtractApplicant(reader));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving applicants: {ex.Message}");
                }
            }

            return applicants;
        }
        public void InsertApplicant(Applicant applicant)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = @"insert into Applicants 
                                         (FirstName, LastName, Email, Phone, Resume) 
                                         values
                                         (@FirstName, @LastName, @Email, @Phone, @Resume)";
                    _cmd.Connection = conn;

                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@FirstName", applicant.FirstName);
                    _cmd.Parameters.AddWithValue("@LastName", applicant.LastName);
                    _cmd.Parameters.AddWithValue("@Email", applicant.Email);
                    _cmd.Parameters.AddWithValue("@Phone", applicant.Phone);
                    _cmd.Parameters.AddWithValue("@Resume", string.IsNullOrEmpty(applicant.Resume) ? DBNull.Value : (object)applicant.Resume);

                    conn.Open();
                    _cmd.ExecuteNonQuery();

                    Console.WriteLine("Applicant inserted successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting applicant: {ex.Message}");
                }
            }
        }

        private Applicant ExtractApplicant(SqlDataReader reader)
        {
            return new Applicant
            {
                ApplicantID = (int)reader["ApplicantID"],
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Email = reader["Email"].ToString(),
                Phone = reader["Phone"].ToString(),
                Resume = reader["Resume"] == DBNull.Value ? null : reader["Resume"].ToString()
            };
        }

    }
}
