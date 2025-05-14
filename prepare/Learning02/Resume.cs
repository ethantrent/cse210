using System;
using System.Collections.Generic;

// Create the Resume class
public class Resume
{
    // Member variables
    public string _name;
    public List<Job> _jobs = new List<Job>();

    // Method to display the resume
    public void Display() // void means no return value, meaning it doesn't return anything
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        
        // Loop through each job in the jobs list
        foreach (Job job in _jobs)
        {
            // Call the Display method on each job
            job.Display();
        }
    }
}