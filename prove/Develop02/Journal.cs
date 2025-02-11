using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private List<string> _prompts = new List<string>
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
        string prompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        int mood;
        do
        {
            Console.Write("Rate your mood (1-5): ");
        } while (!int.TryParse(Console.ReadLine(), out mood) || mood < 1 || mood > 5);

        Entry newEntry = new Entry(prompt, response, mood);
        _entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries yet.");
            return;
        }

        foreach (var entry in _entries)
        {
            entry.DisplayEntry();
        }
    }

    public void SearchEntries()
    {
        Console.Write("Enter keyword to search: ");
        string keyword = Console.ReadLine().ToLower();

        var foundEntries = _entries.FindAll(e => e.GetFormattedEntry().ToLower().Contains(keyword));

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

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine(entry.GetFormattedEntry());
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found. No entries loaded.");
            return;
        }

        _entries.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Entry entry = Entry.FromFormattedEntry(line);
                if (entry != null)
                {
                    _entries.Add(entry);
                }
            }
        }
        Console.WriteLine("Journal loaded successfully.");
    }
}
