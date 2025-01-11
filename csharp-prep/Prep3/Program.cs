using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);  // Random number between 1 and 100
        int guess;  // Declare guess as an integer

        Console.WriteLine("Welcome to Guess the Number, where you have to guess the number correctly to win. Don't worry, the number changes every time you play!");

        // Game loop: Keep asking until the guess is correct
        do
        {
            Console.Write("What is your guess? ");
            string input = Console.ReadLine();  // Get input as string
            
            // Try to convert the input to an integer
            if (!int.TryParse(input, out guess))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;  // Skip the rest of the loop and ask for input again
            }

            // Compare the guess with the random number
            if (guess < number)
            {
                Console.WriteLine("Too low! Try again.");
            }
            else if (guess > number)
            {
                Console.WriteLine("Too high! Try again.");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed the number correctly.");
            }

        } while (guess != number);  // Repeat until the guess is correct
    }
}
