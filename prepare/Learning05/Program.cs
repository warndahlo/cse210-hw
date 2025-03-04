using System;
using System.Collections.Generic;

// Abstract base class
public abstract class Shape
{
    public string Color { get; set; }
    
    public Shape(string color)
    {
        Color = color;
    }
    
    // Abstract method to be overridden by derived classes
    public abstract double GetArea();
}

// Square class
public class Square : Shape
{
    private double side;

    public Square(string color, double side) : base(color)
    {
        this.side = side;
    }

    public override double GetArea()
    {
        return side * side;
    }
}

// Rectangle class
public class Rectangle : Shape
{
    private double length;
    private double width;

    public Rectangle(string color, double length, double width) : base(color)
    {
        this.length = length;
        this.width = width;
    }

    public override double GetArea()
    {
        return length * width;
    }
}

// Circle class
public class Circle : Shape
{
    private double radius;

    public Circle(string color, double radius) : base(color)
    {
        this.radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * radius * radius;
    }
}

// Main Program
class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>
        {
            new Square("Red", 5),
            new Rectangle("Blue", 4, 6),
            new Circle("Green", 3)
        };

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.Color}, Area: {shape.GetArea():F2}");
        }
    }
}
