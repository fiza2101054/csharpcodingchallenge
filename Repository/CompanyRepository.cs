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
    internal class CompanyRepository : ICompanyRepository
    {
        private readonly string connectionString;
        private SqlCommand _cmd;

        public CompanyRepository()
        {
            connectionString = DBConnUtil.GetConnectionString();
            _cmd = new SqlCommand();
        }


        public List<Company> GetCompanies()
        {
            List<Company> companies = new List<Company>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = "select * from companies";
                    _cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = _cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            companies.Add(ExtractCompany(reader));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return companies;
        }

        public void InsertCompany(Company company)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = @"insert into Companies 
                                         (CompanyName, Location) 
                                         values 
                                         (@CompanyName, @Location)";
                    _cmd.Connection = conn;

                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@CompanyName", company.CompanyName);
                    _cmd.Parameters.AddWithValue("@Location", company.Location);

                    conn.Open();
                    _cmd.ExecuteNonQuery();
                    Console.WriteLine("Company added successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding company: {ex.Message}");
                }
            }
        }

        private Company ExtractCompany(SqlDataReader reader)
        {
            return new Company
            {
                CompanyID = (int)reader["CompanyId"],
                CompanyName = reader["CompanyName"].ToString(),
                Location = reader["Location"] == DBNull.Value ? null : reader["Location"].ToString()
            };
        }

    }
}
