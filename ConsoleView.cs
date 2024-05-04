using System;
using System.Collections.Generic;

public class ConsoleView : IView
{
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void ShowEvents(IEnumerable<Event> events)
    {
        foreach (var e in events)
        {
            Console.WriteLine($"[{e.DateTime}] {e.Description}");
        }
    }
}
