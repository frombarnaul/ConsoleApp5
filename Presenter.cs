using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Presenter : IPresenter
{
    private List<Event> events;
    private readonly IView view;

    public Presenter(IView view)
    {
        this.view = view;
        this.events = new List<Event>();
    }

    public void AddEvent(DateTime dateTime, string description)
    {
        var newEvent = new Event { DateTime = dateTime, Description = description };
        events.Add(newEvent);
        view.ShowMessage("Event added successfully.");
    }

    public void ShowEvents(DateTime date)
    {
        var eventsToShow = events.Where(e => e.DateTime.Date == date.Date);
        view.ShowEvents(eventsToShow);
    }

    public void SaveEventsToFile(string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var e in events)
                {
                    writer.WriteLine($"{e.DateTime:s}|{e.Description}");
                }
            }
            view.ShowMessage("Events saved to file successfully.");
        }
        catch (Exception ex)
        {
            view.ShowMessage($"Error saving events: {ex.Message}");
        }
    }

    public void LoadEventsFromFile(string filePath)
    {
        try
        {
            events.Clear();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 2 && DateTime.TryParse(parts[0], out DateTime dateTime))
                    {
                        var description = parts[1];
                        events.Add(new Event { DateTime = dateTime, Description = description });
                    }
                }
            }
            view.ShowMessage("Events loaded from file successfully.");
        }
        catch (Exception ex)
        {
            view.ShowMessage($"Error loading events: {ex.Message}");
        }
    }

    public void SortEventsByDateTime()
    {
        events.Sort((e1, e2) => e1.DateTime.CompareTo(e2.DateTime));
        view.ShowMessage("Events sorted by date and time.");
    }

    public void SearchEventsByDate(DateTime startDate, DateTime endDate)
    {
        var eventsInRange = events.Where(e => e.DateTime.Date >= startDate.Date && e.DateTime.Date <= endDate.Date);
        view.ShowEvents(eventsInRange);
    }
}
