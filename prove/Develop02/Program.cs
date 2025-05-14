using System;

class Program
{
    static void Main(string[] args)
    {
        // Create instance for the journal class
        Journal journal = new Journal();
        //Create instance for the prompt generator class
        PromptGenerator promptGenerator = new PromptGenerator();
    
        bool running = true;

        // while loop to keep the program running until the user chooses to quit
        while (running)
        {
            // Display the menu options to the user
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("\nWhat would you like to do? ");
            
            // get and read the user input
            string choice = Console.ReadLine();

            // switch statement to handle the user input
            switch (choice)
            {
                case "1": // write new entry
                    Entry entry = new();
                    entry._date = DateTime.Now.ToShortDateString();
                    entry._promptText = promptGenerator.GetRandomPrompt();
                    
                    Console.WriteLine(entry._promptText);
                    Console.Write("> ");
                    entry._entryText = Console.ReadLine();
                    
                    journal.AddEntry(entry);
                    break;

                case "2": // display entries
                    journal.DisplayAll();
                    break;

                case "3": // load from file
                    Console.WriteLine("Load from:");
                    Console.WriteLine("1. Text File");
                    Console.WriteLine("2. JSON File");
                    Console.Write("> ");
                    string loadOption = Console.ReadLine();
                    
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    
                    if (loadOption == "1")
                    {
                        journal.LoadFromFile(loadFile);
                    }
                    else if (loadOption == "2")
                    {
                        journal.LoadFromJsonFile(loadFile);
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Using text file as default.");
                        journal.LoadFromFile(loadFile);
                    }
                    break;

                case "4": // save to file
                    Console.WriteLine("Save as:");
                    Console.WriteLine("1. Text File");
                    Console.WriteLine("2. JSON File");
                    Console.Write("> ");
                    string saveOption = Console.ReadLine();
                    
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    
                    if (saveOption == "1")
                    {
                        journal.SaveToFile(saveFile);
                    }
                    else if (saveOption == "2")
                    {
                        journal.SaveToJsonFile(saveFile);
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Using text file as default.");
                        journal.SaveToFile(saveFile);
                    }
                    break;

                case "5": // quit
                    running = false;
                    break;

                default: // if none selected
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}