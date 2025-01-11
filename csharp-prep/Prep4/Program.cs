using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();  // Declare the list outside the loop
        int number = -1;

        while (number != 0)
        {
            Console.WriteLine("Enter any values, when you are done enter 0");
            Console.Write("What is the number? ");
            string input = Console.ReadLine();
            number = int.Parse(input);

            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        // Calculate the sum after exiting the loop
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        Console.WriteLine($"The sum is: {sum}");

        // Calculate the average
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Find the max number
        int max = numbers[0]; // Assume the first number is the max initially
        foreach (int num in numbers)
        {
            if (num > max) // Compare the current number with the max value
            {
                max = num;
            }
        }
        Console.WriteLine($"The max is: {max}");
    }
}
