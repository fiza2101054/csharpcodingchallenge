using Careerhubcoding.Model;
using Careerhubcoding.Service;

namespace Careerhubcoding.Main
{
    internal class main
    {
        static void Main(string[] args)
        {
            IJobListingService jobListingService = new JobListingService();
            IApplicantService applicantService = new ApplicantService();
            ICompanyService companyService = new CompanyService();
            IApplicationService applicationService = new ApplicationService();


            bool continueRunning = true;

            while (continueRunning)
            {
                // Menu
                Console.WriteLine("\n----------CareerHub Job Management-----------");
                Console.WriteLine("1. View All Job Listings");
                Console.WriteLine("2. Add a New Job Listing");
                Console.WriteLine("3.  View all Applicants");
                Console.WriteLine("4. Add a New Applicant");
                Console.WriteLine("5. View AllCompanies");
                Console.WriteLine("6. Add a new Company");
                Console.WriteLine("7. View Applications for a Job");
                Console.WriteLine("8. Apply for a Job");




                Console.Write("Choose an option: ");


                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":

                        jobListingService.GetAllJobListings();
                        break;

                    case "2":

                        JobListing newJob = new JobListing();

                        Console.Write("\nEnter Company ID: ");
                        newJob.CompanyID = int.Parse(Console.ReadLine());

                        Console.Write("Enter Job Title: ");
                        newJob.JobTitle = Console.ReadLine();

                        Console.Write("Enter Job Description (optional): ");
                        string jobDescription = Console.ReadLine();
                        newJob.JobDescription = string.IsNullOrWhiteSpace(jobDescription) ? null : jobDescription;

                        Console.Write("Enter Job Location: ");
                        newJob.JobLocation = Console.ReadLine();

                        Console.Write("Enter Salary: ");
                        newJob.Salary = decimal.Parse(Console.ReadLine());

                        Console.Write("Enter Job Type: ");
                        newJob.JobType = Console.ReadLine();

                        Console.Write("Enter Posted Date (YYYY-MM-DD): ");
                        newJob.PostedDate = DateTime.Parse(Console.ReadLine());


                        jobListingService.InsertJobListing(newJob);
                        break;


                    case "3":

                        applicantService.GetApplicants();
                        break;


                    case "4":

                        Applicant newApplicant = new Applicant();

                        Console.Write("\nEnter First Name: ");
                        newApplicant.FirstName = Console.ReadLine();

                        Console.Write("Enter Last Name: ");
                        newApplicant.LastName = Console.ReadLine();

                        Console.Write("Enter Email: ");
                        newApplicant.Email = Console.ReadLine();

                        Console.Write("Enter Phone: ");
                        newApplicant.Phone = Console.ReadLine();

                        Console.Write("Enter Resume: ");
                        string resume = Console.ReadLine();
                        newApplicant.Resume = string.IsNullOrWhiteSpace(resume) ? null : resume;


                        applicantService.InsertApplicant(newApplicant);

                        break;

                    case "5":

                        companyService.GetCompanies();
                        break;

                    case "6":

                        Company newCompany = new Company();

                        Console.Write("\nEnter Company Name: ");
                        newCompany.CompanyName = Console.ReadLine();

                        Console.Write("Enter Company Location: ");
                        newCompany.Location = Console.ReadLine();

                        companyService.InsertCompany(newCompany);
                        break;


                    case "7":

                        Console.Write("Enter Job ID to view applications: ");
                        int jobID = int.Parse(Console.ReadLine());
                        applicationService.GetApplicationsForJob(jobID);
                        break;

                    case "8":

                        Application newApplication = new Application();

                        Console.Write("Enter Job ID you are applying for: ");
                        newApplication.JobID = int.Parse(Console.ReadLine());

                        Console.Write("Enter Your Applicant ID: ");
                        newApplication.ApplicantID = int.Parse(Console.ReadLine());

                        Console.Write("Enter Application Date (YYYY-MM-DD): ");
                        newApplication.ApplicationDate = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter Cover Letter (optional): ");
                        newApplication.CoverLetter = Console.ReadLine();

                        applicationService.ApplyForJob(newApplication);
                        break;



                    case "9":

                        continueRunning = false;
                        Console.WriteLine("Exiting the program. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
    }
}
