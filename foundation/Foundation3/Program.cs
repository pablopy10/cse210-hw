using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("03 Nov 2022", 30, 3.0),
            new Cycling("03 Nov 2022", 40, 18.0),
            new Swimming("03 Nov 2022", 45, 20)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

public abstract class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public int GetMinutes() { return _minutes; }

    public virtual double GetDistance() { return 0; }
    public virtual double GetSpeed() { return 0; }
    public virtual double GetPace() { return 0; }

    public virtual string GetSummary()
    {
        return $"{_date} - Duration: {_minutes} min, Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min/mile";
    }
}

public class Running : Activity
{
    private double _distance;

    public Running(string date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() { return _distance; }
    public override double GetSpeed() { return (GetDistance() / GetMinutes()) * 60; }
    public override double GetPace() { return GetMinutes() / GetDistance(); }
}

public class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetSpeed() { return _speed; }
    public override double GetDistance() { return (GetSpeed() * GetMinutes()) / 60; }
    public override double GetPace() { return 60 / GetSpeed(); }
}

public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() { return (_laps * 50) / 1000.0 * 0.62; }
    public override double GetSpeed() { return (GetDistance() / GetMinutes()) * 60; }
    public override double GetPace() { return GetMinutes() / GetDistance(); }
}
