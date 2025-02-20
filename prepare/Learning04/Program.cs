using System;

class Program
{
    static void Main()
    {
        MathAssignment math = new MathAssignment("Calculus", "John Doe", "Integration Techniques", "Chapter 5");
        WritingAssignment writing = new WritingAssignment("English", "Jane Smith", "The Great Gatsby Essay");

        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());
        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());
    }
}
