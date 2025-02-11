using System;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;
    private int _mood;

    public Entry(string prompt, string response, int mood)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _prompt = prompt;
        _response = response;
        _mood = mood;
    }

    public string GetFormattedEntry()
    {
        return $"{_date}|{_mood}|{_prompt}|{_response}";
    }

    public static Entry FromFormattedEntry(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length == 4)
        {
            return new Entry(parts[2], parts[3], int.Parse(parts[1]));
        }
        return null;
    }

    public void DisplayEntry()
    {
        Console.WriteLine($"[{_date}] - Mood: {_mood}/5");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"→ {_response}\n");
    }
}
