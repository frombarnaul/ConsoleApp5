using System;
using System.Collections.Generic;

public interface IView
{
    void ShowMessage(string message);
    void ShowEvents(IEnumerable<Event> events);
}
