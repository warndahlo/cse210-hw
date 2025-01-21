using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    public List<Entry> Entries { get; private set; } = new List<Entry>();

    public void AddEntry(string prompt, string response, string date)
    {
        Entries.Add(new Entry(date, prompt, response));
    }

    public void DisplayEntries()
    {
        if (Entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal.");
        }
        else
        {
            foreach (var entry in Entries)
            {
                Console.WriteLine(entry);
            }
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            var json = JsonSerializer.Serialize(Entries);
            File.WriteAllText(filename, json);
            Console.WriteLine("Journal saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            try
            {
                var json = File.ReadAllText(filename);
                Entries = JsonSerializer.Deserialize<List<Entry>>(json) ?? new List<Entry>();
                Console.WriteLine("Journal loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
