using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("what is your first name? ");
        string first = Console.ReadLine();
        
        Console.Write("What is your last name? ");
        string last = Console.ReadLine();


        Console.WriteLine($"your name is {last}, {first} {last}");
    }
}