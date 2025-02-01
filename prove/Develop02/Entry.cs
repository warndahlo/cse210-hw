using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public int Mood { get; set; } // Mood rating (1-5)

    public Entry(string prompt, string response, int mood)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    public void DisplayEntry()
    {
        Console.WriteLine($"[{Date}] - Mood: {Mood}/5");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"→ {Response}\n");
    }
}
