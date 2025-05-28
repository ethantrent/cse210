using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a scripture
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        Scripture scripture = new Scripture(reference, text);

        bool isCompletelyHidden = false;

        while (!isCompletelyHidden)
        {
            // Clear the console and display the scripture
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            // Prompt the user
            Console.Write("Press enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            // Hide random words and check if all words are hidden
            isCompletelyHidden = scripture.HideRandomWords(3);
        }

        // if all words are hidden
        if (isCompletelyHidden)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nAll words are now hidden!");
        }
    }
}