using System;
using System.Collections.Generic;
using System.Globalization;

public class Activity
{
    private DateTime _date;
    private int _durationMinutes;

    public Activity(DateTime date, int durationMinutes)
    {
        _date = date;
        _durationMinutes = durationMinutes;
    }

    public DateTime Date => _date;
    public int DurationMinutes => _durationMinutes;

    public virtual double GetDistance() => 0;
    public virtual double GetSpeed() => 0;
    public virtual double GetPace() => 0;

    public virtual string GetSummary()
    {
        string formattedDate = _date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
        return $"{formattedDate} Activity ({_durationMinutes} min)";
    }
}

public class Running : Activity
{
    private double _distanceMiles;

    public Running(DateTime date, int durationMinutes, double distanceMiles) 
        : base(date, durationMinutes)
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance() => _distanceMiles;
    public override double GetSpeed() => (GetDistance() / DurationMinutes) * 60;
    public override double GetPace() => DurationMinutes / GetDistance();

    public override string GetSummary()
    {
        string formattedDate = Date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
        return $"{formattedDate} Running ({DurationMinutes} min) - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}

public class Cycling : Activity
{
    private double _speedMph;

    public Cycling(DateTime date, int durationMinutes, double speedMph) 
        : base(date, durationMinutes)
    {
        _speedMph = speedMph;
    }

    public override double GetDistance() => (_speedMph * DurationMinutes) / 60;
    public override double GetSpeed() => _speedMph;
    public override double GetPace() => 60 / _speedMph;

    public override string GetSummary()
    {
        string formattedDate = Date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
        return $"{formattedDate} Cycling ({DurationMinutes} min) - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}

public class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMiles = 50.0 / 1000.0 * 0.62; // 50 meters converted to miles

    public Swimming(DateTime date, int durationMinutes, int laps) 
        : base(date, durationMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * LapLengthMiles;
    public override double GetSpeed() => (GetDistance() / DurationMinutes) * 60;
    public override double GetPace() => DurationMinutes / GetDistance();

    public override string GetSummary()
    {
        string formattedDate = Date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
        return $"{formattedDate} Swimming ({DurationMinutes} min) - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 4), 45, 15.0),
            new Swimming(new DateTime(2022, 11, 5), 20, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
