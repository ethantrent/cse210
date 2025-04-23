using System;

class Program
{
    static void Main(string[] args)
    {
        // users first name
        Console.Write("What is your first name? ");
        string fname = Console.ReadLine();

        // users last name
        Console.Write("What is your last name? ");
        string lname = Console.ReadLine();

        // print as James Bond style
        Console.WriteLine($"Your name is {lname}, {fname} {lname}.");
    }
}