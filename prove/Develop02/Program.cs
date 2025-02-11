using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        bool running = true;
        string filename = "journal.txt";

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal entries");
            Console.WriteLine("3. Search journal entries");
            Console.WriteLine("4. Save journal to a file");
            Console.WriteLine("5. Load journal from a file");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SearchEntries();
                    break;
                case "4":
                    journal.SaveToFile(filename);
                    break;
                case "5":
                    journal.LoadFromFile(filename);
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

/*
====================================
🚀 EXCEEDING CORE REQUIREMENTS 🚀
====================================
1️⃣ **Mood Tracking**  
   - Each journal entry now includes a mood rating (1-5).  
   - Users are prompted to rate their mood after writing an entry.  
   - Entries display mood levels for better reflection.

2️⃣ **Search Functionality**  
   - Users can search for past journal entries by keyword.  
   - This makes it easy to find reflections on specific topics.  

3️⃣ **Saving & Loading Entries**  
   - Journal entries are saved to a text file (`journal.txt`).  
   - Users can reload their previous journal entries anytime.  
   - This prevents data loss when closing the program.

4️⃣ **Better Formatting & Readability**  
   - Journal entries are displayed with clear formatting.  
   - Each entry shows the date, mood, prompt, and response.  

5️⃣ **User-Friendly Menu System**  
   - The program provides clear prompts and structured choices.  
   - Input validation ensures users provide correct data.  
*/
