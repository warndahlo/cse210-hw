using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        bool playAgain = true;
        while (playAgain)
        {
            // List of scriptures
            List<Scripture> scriptures = new List<Scripture>
            {
                new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
                new Scripture(new Reference("2 Nephi", 2, 25), "Adam fell that men might be; and men are, that they might have joy."),
                new Scripture(new Reference("Alma", 37, 6), "By small and simple things are great things brought to pass."),
                new Scripture(new Reference("Moses", 1, 39), "For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man."),
                new Scripture(new Reference("D&C", 18, 10), "Remember the worth of souls is great in the sight of God."),
            };

            // Select a random scripture
            Random rand = new Random();
            Scripture scripture = scriptures[rand.Next(scriptures.Count)];

            // Choose difficulty level
            Console.WriteLine("Select difficulty: Easy (1 word per round), Medium (3 words per round), Hard (5 words per round)");
            Console.Write("Enter choice (easy, medium, hard): ");
            string difficultyChoice = Console.ReadLine().ToLower();
            int wordsToHide = difficultyChoice switch
            {
                "easy" => 1,
                "medium" => 3,
                "hard" => 5,
                _ => 3 // Default to medium
            };

            // Scripture memorization loop
            while (!scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                    return;

                scripture.HideWords(wordsToHide);
            }

            Console.Clear();
            Console.WriteLine("All words are hidden! Great job memorizing.");

            // Ask to play again
            Console.Write("Would you like to play again? (yes/no): ");
            string replayChoice = Console.ReadLine().ToLower();
            playAgain = replayChoice == "yes";
        }
    }
}

class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int? EndVerse { get; }

    public Reference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        return EndVerse == null ? $"{Book} {Chapter}:{StartVerse}" : $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}

class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide() => IsHidden = true;

    public override string ToString() => IsHidden ? "_____" : Text;
}

class Scripture
{
    private Reference Reference { get; }
    private List<Word> Words { get; }
    private Random random = new Random();

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public string GetDisplayText()
    {
        return Reference + "\n" + string.Join(" ", Words);
    }

    public void HideWords(int count)
    {
        var visibleWords = Words.Where(w => !w.IsHidden).ToList();
        int wordsToHide = Math.Min(count, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden() => Words.All(w => w.IsHidden);
}

/*
    --- Extra Features Added ---
    1. Added multiple scriptures from LDS sources (Proverbs, 2 Nephi, Alma, Moses, D&C)
    2. Implemented difficulty levels:
       - Easy: Hides 1 word per round
       - Medium: Hides 3 words per round
       - Hard: Hides 5 words per round
    3. Allows replaying after completing one scripture
*/
