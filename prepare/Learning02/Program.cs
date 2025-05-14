using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of the Job class
        Job job1 = new("Software Engineer", "Twitch", 2026, 2070);
        
        job1.Display();

        // // Create another instance of the Job class
        // Job job2 = new();
        // job2._jobTitle = "Software Manager";
        // job2._company = "Google";
        // job2._startYear = 2026;
        // job2._endYear = 2070;

        // Create an instance of the Resume class
        Resume resume = new();
        resume._name = "Ethan Trent";
        // Add the jobs to the resume
        resume._jobs.Add(job1);
        // resume._jobs.Add(job2);

        // Call the Display method to show the resume
        // resume.Display();

        // Create an instance of the Applicant class
        Applicant applicant = new();
        applicant._firstName = "Ethan";
        applicant._lastName = "Trent";
        applicant._phoneNumber = "641-451-0659";
        applicant._emailAddress = "ethanjotrent@gmail.com";
        applicant._orderOfApplication = 1;
        applicant._rank = 1;
        applicant._resume = resume;

        // Call the Display method to show the applicant's information
        applicant.Display();
    }
}