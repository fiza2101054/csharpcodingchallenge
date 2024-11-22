using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Careerhubcoding.Model
{
    internal class Applicant
    {

        private int _applicantID;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        private string? _resume;
        public int ApplicantID
        {
            get { return _applicantID; }
            set { _applicantID = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string? Resume
        {
            get { return _resume; }
            set { _resume = value; }
        }

        public override string ToString()
        {
            return $"Applicant ID: {ApplicantID}\t" +
                   $"Name: {FirstName} {LastName}\t" +
                   $"Email: {Email}\t" +
                   $"Phone: {Phone}\t" +
                   $"Resume: {(string.IsNullOrEmpty(Resume) ? "Not Provided" : "Available")}";
        }  
    }
}
