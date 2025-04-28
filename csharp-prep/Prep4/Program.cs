/* Ask the user for a series of numbers, and append each one to a list. Stop when they enter 0.

Once you have a list, have your program do the following:

Compute the sum, or total, of the numbers in the list.

Compute the average of the numbers in the list.

Find the maximum, or largest, number in the list. */

using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new list to hold the numbers
        List<int> numbers = new List<int>();

        int userNumber = -1; // Initialize to a value that won't be 0

        // Ask the user for numbers until they enter 0
        while (userNumber != 0)
        {
            // Prompt the user for input
            Console.Write("Enter a number (0 to stop): ");
            // Read the user input
            string userResponse = Console.ReadLine();
            // Convert the input to an integer
            userNumber = int.Parse(userResponse);

            // Add the number to the list if it's not 0
            if (userNumber != 0)
            {
                // Add the number to the list
                numbers.Add(userNumber);
            }
        }

            // Sum, average, and max calculations

            // Calculate the sum of the numbers in the list
            int sum = 0;

            foreach (int number in numbers)
            {
                sum += number; // Add each number to the sum

            }

            // print the number to the console
                Console.WriteLine($"The sum is: {sum}");

            // Calculate the average
            double average = 0.0;
            
            // find the average of the numbers in the list
            average = (double)sum / numbers.Count;

            // print the average to the console
                Console.WriteLine($"The average is: {average}");

            // Find the maximum number in the list
            int max = numbers[0];

            foreach (int number in numbers)
            {
                // Check if the current number is greater than the current max
                if (number > max)
                {
                    // Update max if the current number is greater
                    max = number;
                }
            }

            // print the max to the console
            Console.WriteLine($"The maximum number is: {max}");
    } 
}