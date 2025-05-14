using System;

public class Entry
{
    // Change fields to properties for better JSON serialization
    public string _date { get; set; }
    public string _promptText { get; set; }
    public string _entryText { get; set; }

    public void Display()
    {
        // display all entry details
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine();
    }
}