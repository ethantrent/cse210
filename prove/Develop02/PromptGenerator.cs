using System;
using System.Collections.Generic;

// Generat prompts for the journal
public class PromptGenerator 
{
    // create list for prompts
    List<string> _prompts;

    // create constructor
    public PromptGenerator()
    {
        // initialize list of prompts
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What was the most challenging thing I faced today?",
            "What am I grateful for today?",
            "What did I learn today that I want to remember?",
            "What made me smile today?",
            "What would I like to accomplish tomorrow?"
        };
    }

    public string GetRandomPrompt()
        {
            // get random prompt from list
            Random random = new();
            int index = random.Next(_prompts.Count);
            return _prompts[index];
        }
}