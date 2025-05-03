using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of the Job class
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Twitch";
        job1._startYear = 2026;
        job1._endYear = 2070;

        // Create another instance of the Job class
        Job job2 = new Job();
        job2._jobTitle = "Software Manager";
        job2._company = "Google";
        job2._startYear = 2026;
        job2._endYear = 2070;

        // Create an instance of the Resume class
        Resume resume = new Resume();
        resume._name = "Ethan Trent";
        // Add the jobs to the resume
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        // Call the Display method to show the resume
        resume.Display();
    }
}