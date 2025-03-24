using System;
using System.Collections.Generic;

abstract class Activity
{
    protected string Date;
    protected int Duration; // Minutes

    public Activity(string date, int duration)
    {
        Date = date;
        Duration = duration;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{Date} {this.GetType().Name} ({Duration} min): Distance {GetDistance():F2} km, Speed {GetSpeed():F2} kph, Pace {GetPace():F2} min per km";
    }
}

class Running : Activity
{
    private double Distance;

    public Running(string date, int duration, double distance) : base(date, duration)
    {
        Distance = distance;
    }

    public override double GetDistance() => Distance;
    public override double GetSpeed() => (Distance / Duration) * 60;
    public override double GetPace() => Duration / Distance;
}

class Cycling : Activity
{
    private double Speed;

    public Cycling(string date, int duration, double speed) : base(date, duration)
    {
        Speed = speed;
    }

    public override double GetDistance() => (Speed * Duration) / 60;
    public override double GetSpeed() => Speed;
    public override double GetPace() => 60 / Speed;
}

class Swimming : Activity
{
    private int Laps;

    public Swimming(string date, int duration, int laps) : base(date, duration)
    {
        Laps = laps;
    }

    public override double GetDistance() => (Laps * 50) / 1000.0;
    public override double GetSpeed() => (GetDistance() / Duration) * 60;
    public override double GetPace() => Duration / GetDistance();
}

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("03 Nov 2022", 30, 4.8),
            new Cycling("03 Nov 2022", 30, 20),
            new Swimming("03 Nov 2022", 30, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
