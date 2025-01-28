using System;
using System.Collections.Generic;

namespace JournalApp
{
    public class JournalProgram
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

        public static void Main()
        {
            JournalProgram program = new JournalProgram();
            program.Run();
        }

        public void Run()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        WriteNewEntry();
                        break;
                    case "2":
                        DisplayJournal();
                        break;
                    case "3":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("Journal Program");
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
        }

        private void WriteNewEntry()
        {
            Random random = new Random();
            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine("Today's prompt: " + prompt);
            Console.Write("Your response: ");
            string response = Console.ReadLine();
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            entries.Add(new Entry(date, prompt, response));
            Console.WriteLine("Entry saved.");
            Console.ReadLine();
        }

        private void DisplayJournal()
        {
            Console.Clear();
            if (entries.Count == 0)
            {
                Console.WriteLine("Your journal is empty.");
            }
            else
            {
                foreach (var entry in entries)
                {
                    Console.WriteLine($"Date: {entry.Date}");
                    Console.WriteLine($"Prompt: {entry.Prompt}");
                    Console.WriteLine($"Response: {entry.Response}");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Press Enter to return to the menu.");
            Console.ReadLine();
        }
    }
}
