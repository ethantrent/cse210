/* Write a program that determines the letter grade for a course according to the following scale:

A >= 90
B >= 80
C >= 70
D >= 60
F < 60 */

using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        // users grade percentage
        Console.Write("What is your grade percentage? ");
        // read users percentage
        string gradePercentage = Console.ReadLine();
        // convert string to int
        int grade = int.Parse(gradePercentage);

        // check if grade is A, B, C, D, or F

        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // print letter grade
        Console.WriteLine($"You got a {letter}!");

        // check if grade is passing or failing
        if (grade >= 70)
        {
            // Add the code to execute when the condition is true
            Console.WriteLine("You passed the class! Congrats!");
        }
        else
        {
            Console.WriteLine("You need to retake the course, better luck next time!");   
        }
    }
}