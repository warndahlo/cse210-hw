using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("what is your grade percent? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);
        string letter = "";

        if (percent >= 90)
    {
        letter = "A";
    }
        else if (percent >= 80)
    {     
        letter = "B";
    }
        else if (percent >= 70)
    {
        letter = "C";
    }
        else if (percent >= 60)
    {
        letter = "D";
    }
    else    
    {
        letter = "F";
    }
    
        Console.WriteLine($"Your grade is {letter}! ");
        if (percent >= 70)
    {   Console.WriteLine("Congrats, you passed the class!");}
        else
    {   Console.WriteLine("You didn't pass, try again next time!");}


    }
}