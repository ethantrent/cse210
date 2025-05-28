using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a library of scriptures
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            ),
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
            ),
            new Scripture(
                new Reference("1 Nephi", 3, 7),
                "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."
            ),
            new Scripture(
                new Reference("Alma", 32, 21),
                "And now as I said concerning faith—faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true."
            )
        };

        // Choose a random scripture
        Random random = new Random();
        Scripture currentScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];
        
        bool isCompletelyHidden = false;

        while (!isCompletelyHidden)
        {
            // Clear the console and display the scripture
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());

            // Prompt the user
            Console.Write("\nPress enter to continue, type 'new' for a new scripture, or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }
            else if (input.ToLower() == "new")
            {
                // Choose a different scripture
                currentScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];
                isCompletelyHidden = false;
            }
            else
            {
                // Hide random words and check if all words are hidden
                isCompletelyHidden = currentScripture.HideRandomWords(3);
            }
        }

        // if all words are hidden
        if (isCompletelyHidden)
        {
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine("\nAll words are now hidden!");
        }
    }
}