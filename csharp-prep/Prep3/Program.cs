/* Start by asking the user for the magic number. (In future steps, we will change this to have the computer generate a random number, but to get started, we'll just let the user decide what it is.)

Ask the user for a guess.

Using an if statement, determine if the user needs to guess higher or lower next time, or tell them if they guessed it. */

using System;

class Program
{
    static void Main(string[] args)
    {
        /* Part 1 & 2
        Console.Write("Enter the Magic Number: ");
        string magicNumberInput = Console.ReadLine();
        int magicNumber = int.Parse(magicNumberInput);
        guess = int.Parse(answer); */

        // Part 3: Generate a random number between 1 and 100
        Random random = new Random();
        int magicNumber = random.Next(1, 101); // Generates a number between 1 and 100 (inclusive)

        // Initialize guess to a value that won't match magicNumber
        int guess = -1;

        // while loop to keep asking for a guess until the user guesses the magic number
        while (guess != magicNumber)
        {
            // ask user for a guess
            Console.Write("Guess the Magic Number: ");
            // read user input
            guess = int.Parse(Console.ReadLine());
            // guess = Convert.ToInt32(Console.ReadLine());

            // check to see if guess is correct
            if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else 
            {
               Console.WriteLine("That is correct! Great job!");
            }
        }
    }
}