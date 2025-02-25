using System;
using System.Collections.Generic;
using System.Threading;

// Base class for all mindfulness activities
abstract class MindfulnessActivity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Starting {_name} activity...");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        DisplayAnimation(3);
        PerformActivity();
        Console.WriteLine("Good job! Activity complete.");
    }

    protected abstract void PerformActivity();

    // Method for displaying a countdown timer
    protected void DisplayCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i}..."); // Overwrites the previous number
            Thread.Sleep(1000); // Wait for 1 second
        }
        Console.Write("\r "); // Clears the countdown after it's finished
    }

    protected void DisplayAnimation(int seconds)
    {
        char[] spinner = { '|', '/', '-', '\\' };
        for (int i = 0; i < seconds * 4; i++) // 4 frames per second
        {
            Console.Write($"\r{spinner[i % 4]}"); // Use \r to overwrite the previous character
            Thread.Sleep(250); // Speed of animation
        }
        Console.Write("\r "); // Clear the spinner
    }
}

// Breathing Activity
class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", "Focus on your breathing to relax.") { }

    protected override void PerformActivity()
    {
        for (int i = 0; i < _duration / 6; i++)
        {
            Console.WriteLine("Breathe in...");
            DisplayCountdown(3); // Countdown for breathing in
            Console.WriteLine("Breathe out...");
            DisplayCountdown(3); // Countdown for breathing out
        }

        // Play calming sound or music (extra feature)
        PlayCalmingSound();
    }

    // Additional functionality to play calming sound
    private void PlayCalmingSound()
    {
        Console.WriteLine("Playing calming sound... (Imagine soothing music here)");
    }
}

// Listing Activity
class ListingActivity : MindfulnessActivity
{
    public ListingActivity() : base("Listing", "List positive things in your life.") { }

    protected override void PerformActivity()
    {
        Console.WriteLine("Start listing things that make you happy:");
        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("- ");
            responses.Add(Console.ReadLine());
        }

        Console.WriteLine($"You listed {responses.Count} items. Well done!");
    }
}

// Reflecting Activity
class ReflectingActivity : MindfulnessActivity
{
    private static string[] _prompts = {
        "Think of a time you felt truly at peace.",
        "Recall a moment you felt proud of yourself.",
        "Remember a time you helped someone and felt joy."
    };

    private static string[] _questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity() : base("Reflecting", "Think deeply about positive experiences.") { }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        Console.WriteLine(_prompts[rand.Next(_prompts.Length)]);
        Console.WriteLine("Reflect on this for the duration.");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine(_questions[rand.Next(_questions.Length)]);
            DisplayCountdown(5); // Countdown for reflecting
        }

        // Additional feature: Add relaxation technique
        Console.WriteLine("Ending activity with a relaxation technique...");
        Relax();
    }

    // Additional feature: Relaxation technique to close the activity
    private void Relax()
    {
        Console.WriteLine("Take a few deep breaths and relax.");
        DisplayCountdown(5); // Countdown for relaxation
    }
}

// Main Program
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nMindfulness App");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1": new BreathingActivity().StartActivity(); break;
                case "2": new ListingActivity().StartActivity(); break;
                case "3": new ReflectingActivity().StartActivity(); break;
                case "4": return;
                default: Console.WriteLine("Invalid option. Try again."); break;
            }
        }
    }
}
//Extra: Calming sound in Breathing, relaxation technique in Reflecting, enhanced interactive countdown timer.