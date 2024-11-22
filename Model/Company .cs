using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Careerhubcoding.Model
{
    internal class Company
    {

        private int _companyID;
        private string _companyName;
        private string? _location;

    
        public int CompanyID
        {
            get { return _companyID; }
            set { _companyID = value; }
        }

        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        public string? Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public override string ToString()
        {
            return $"Company ID: {CompanyID}\t" +
                   $"Name: {CompanyName}\t" +
                   $"Location: {Location}";
        }  
    }
}
