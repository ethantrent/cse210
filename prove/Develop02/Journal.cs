using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text.Json;

public class Journal
{
//List to hold all the entries
    public List<Entry> _entries;

    public Journal() // constructor
    {
        // Initialize the list of entries
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry) // add method
    {
        // // Add a new entry to the list
        _entries.Add(newEntry);
    }

    public void DisplayAll() // display method
    {
        // Display all entries in the journal
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file) // save to file method
    {
        // Save all entries to a file
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string file) // load from file method
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            
            Entry entry = new Entry();
            entry._date = parts[0];
            entry._promptText = parts[1];
            entry._entryText = parts[2];
            
            _entries.Add(entry);
        }
    }

    public void SaveToJsonFile(string file) 
    {
        try
        {
            // Make sure file has .json extension
            if (!file.EndsWith(".json"))
            {
                file += ".json";
            }

            // Create options to make the JSON more readable
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            // Convert entries to JSON
            string jsonString = JsonSerializer.Serialize(_entries, options);
            
            // Write to file
            File.WriteAllText(file, jsonString);
            Console.WriteLine($"Journal saved to {file} successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to JSON: {ex.Message}");
        }
    }

    public void LoadFromJsonFile(string file)
    {
        try
        {
            // Make sure file has .json extension
            if (!file.EndsWith(".json"))
            {
                file += ".json";
            }

            // Check if file exists
            if (File.Exists(file))
            {
                // Read the JSON string from file
                string jsonString = File.ReadAllText(file);
                
                // Deserialize the JSON into a list of entries
                _entries = JsonSerializer.Deserialize<List<Entry>>(jsonString);
                Console.WriteLine($"Journal loaded from {file} successfully!");
            }
            else
            {
                Console.WriteLine($"File {file} not found!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading from JSON: {ex.Message}");
        }
    }
}