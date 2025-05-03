/*
For this assignment, write a C# program that has several simple functions:

DisplayWelcome - Displays the message, "Welcome to the Program!"
PromptUserName - Asks for and returns the user's name (as a string)
PromptUserNumber - Asks for and returns the user's favorite number (as an integer)
SquareNumber - Accepts an integer as a parameter and returns that number squared (as an integer)
DisplayResult - Accepts the user's name and the squared number and displays them.
Your Main function should then call each of these functions saving the return values and passing data to them as necessary.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome(); // Call the function to display the welcome message
        string name = PromptUserName(); // Call the function to prompt for the user's name
        int number = PromptUserNumber(); // Call the function to prompt for the user's favorite number
        int squaredNumber = SquareNumber(number); // Calculate the squared number
        DisplayResult(name, squaredNumber); // Call the function to display the result
    }
    // static means the method belongs to the class, not an instance of the class
    // void means the method does not return a value
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine(); // Read the user's name
        return name; // Return the name
    }
    static int PromptUserNumber()
    {
        Console.Write("What is your favorite number? ");
        string input = Console.ReadLine(); // Read the user's favorite number
        int number = int.Parse(input); // Convert the input to an integer
        // int number = int.Parse(Console.ReadLine()); // same as above in one line
        return number; // Return the number
    }
    static int SquareNumber(int number)
    {
        return number * number; // Return the squared number
    }
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your favorite number is {squaredNumber}.");
    }
}