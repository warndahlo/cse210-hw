using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries = new List<Entry>();
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void AddEntry()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];

        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        int mood;
        do
        {
            Console.Write("Rate your mood (1-5): ");
        } while (!int.TryParse(Console.ReadLine(), out mood) || mood < 1 || mood > 5);

        Entry newEntry = new Entry(prompt, response, mood);
        entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries yet.");
            return;
        }

        foreach (var entry in entries)
        {
            entry.DisplayEntry();
        }
    }

    public void SearchEntries()
    {
        Console.Write("Enter keyword to search: ");
        string keyword = Console.ReadLine().ToLower();

        var foundEntries = entries.FindAll(e => e.Response.ToLower().Contains(keyword) || e.Prompt.ToLower().Contains(keyword));

        if (foundEntries.Count == 0)
        {
            Console.WriteLine("No matching entries found.");
        }
        else
        {
            Console.WriteLine($"Found {foundEntries.Count} entries:\n");
            foreach (var entry in foundEntries)
            {
                entry.DisplayEntry();
            }
        }
    }

    public void ExportToTxt(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("My Journal Entries");
            writer.WriteLine("===================\n");

            foreach (var entry in entries)
            {
                writer.WriteLine($"[{entry.Date}] - Mood: {entry.Mood}/5");
                writer.WriteLine($"Prompt: {entry.Prompt}");
                writer.WriteLine($"→ {entry.Response}\n");
                writer.WriteLine("---------------------------\n");
            }
        }
        Console.WriteLine("Journal exported to text file successfully.");
    }
}
