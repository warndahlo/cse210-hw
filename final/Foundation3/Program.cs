using System;
using System.Collections.Generic;

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

class Event
{
    private string title;
    private string description;
    private string date;
    private string time;
    private Address address;

    public Event(string title, string description, string date, string time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public virtual string GetEventType()
    {
        return "General Event";
    }

    public string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date}\nTime: {time}\nAddress: {address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: {GetEventType()}";
    }

    public string GetShortDescription()
    {
        return $"{GetEventType()}: {title} on {date}";
    }
}

class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetEventType()
    {
        return "Lecture";
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nSpeaker: {speaker}\nCapacity: {capacity} attendees";
    }
}

class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetEventType()
    {
        return "Reception";
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nRSVP Email: {rsvpEmail}";
    }
}

class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GetEventType()
    {
        return "Outdoor Gathering";
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nWeather Forecast: {weatherForecast}";
    }
}

class Program
{
    static void Main()
    {
        List<Event> events = new List<Event>
        {
            new Lecture("Tech Innovations", "A talk on the latest in tech.", "March 25, 2025", "10:00 AM", new Address("100 Tech Blvd", "San Francisco", "CA", "USA"), "Dr. John Smith", 200),
            new Reception("Networking Night", "An evening of networking with professionals.", "April 10, 2025", "6:00 PM", new Address("456 Business Rd", "New York", "NY", "USA"), "rsvp@example.com"),
            new OutdoorGathering("Spring Festival", "A day of fun and festivities.", "May 5, 2025", "12:00 PM", new Address("789 Park Lane", "Austin", "TX", "USA"), "Sunny, 75°F")
        };

        foreach (var ev in events)
        {
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine("------------------------------------\n");
        }
    }
}
