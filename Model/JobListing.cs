using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Careerhubcoding.Model
{
    internal  class JobListing
    {

        private int _jobID;
        private int _companyID;
        private string _jobTitle;
        private string? _jobDescription;
        private string _jobLocation;
        private decimal _salary;
        private string _jobType;
        private DateTime _postedDate;

        public int JobID
        {
            get { return _jobID; }
            set { _jobID = value; }
        }

        public int CompanyID
        {
            get { return _companyID; }
            set { _companyID = value; }
        }

        public string JobTitle
        {
            get { return _jobTitle; }
            set { _jobTitle = value; }
        }

        public string JobDescription
        {
            get { return _jobDescription; }
            set { _jobDescription = value; }
        }

        public string JobLocation
        {
            get { return _jobLocation; }
            set { _jobLocation = value; }
        }

        public decimal Salary
        {
            get { return _salary; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Salary should not be below zerp");
                }
                _salary = value;
            }
        }

        public string JobType
        {
            get { return _jobType; }
            set { _jobType = value; }
        }

        public DateTime PostedDate
        {
            get { return _postedDate; }
            set { _postedDate = value; }
        }

        public override string ToString()
        {
            return $"Job ID: {JobID}\t" +
                   $"Company ID: {CompanyID}\t" +
                   $"Title: {JobTitle}\t" +
                   $"Location: {JobLocation}\t" +
                   $"Salary: {Salary:C}\t" +
                   $"Type: {JobType}\t" +
                   $"Posted Date: {PostedDate:yyyy-MM-dd}";
        }
    }
}

