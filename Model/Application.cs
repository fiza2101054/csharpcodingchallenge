using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Careerhubcoding.Model
{
    public class Application
    {
        private int _applicationID;
        private int _jobID;
        private int _applicantID;
        private DateTime _applicationDate;
        private string? _coverLetter;

        
        public int ApplicationID
        {
            get { return _applicationID; }
            set { _applicationID = value; }
        }

        public int JobID
        {
            get { return _jobID; }
            set { _jobID = value; }
        }

        public int ApplicantID
        {
            get { return _applicantID; }
            set { _applicantID = value; }
        }

        public DateTime ApplicationDate
        {
            get { return _applicationDate; }
            set { _applicationDate = value; }
        }

        public string? CoverLetter
        {
            get { return _coverLetter; }
            set { _coverLetter = value; }
        }

       
        public override string ToString()
        {
            return $"Application ID: {ApplicationID}\t" +
                   $"Job ID: {JobID}\t" +
                   $"Applicant ID: {ApplicantID}\t" +
                   $"Date: {ApplicationDate:yyyy-MM-dd HH:mm:ss}\t" +
                   $"Cover Letter: {(string.IsNullOrEmpty(CoverLetter) ? "Not Provided" : "Available")}";
        }
    }
}
