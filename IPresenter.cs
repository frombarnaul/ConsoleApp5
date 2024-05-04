using System;
using System.Collections.Generic;

public interface IPresenter
{
    void AddEvent(DateTime dateTime, string description);
    void ShowEvents(DateTime date);
    void SaveEventsToFile(string filePath);
    void LoadEventsFromFile(string filePath);
    void SortEventsByDateTime();
    void SearchEventsByDate(DateTime startDate, DateTime endDate);
}
