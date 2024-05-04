using System;

class Program
{
    static void Main(string[] args)
    {
        IView view = new ConsoleView();
        IPresenter presenter = new Presenter(view);

        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add Event");
            Console.WriteLine("2. Show Events for a Specific Date");
            Console.WriteLine("3. Save Events to File");
            Console.WriteLine("4. Load Events from File");
            Console.WriteLine("5. Sort Events by Date and Time");
            Console.WriteLine("6. Search Events in Date Range");
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter date and time (yyyy-MM-dd HH:mm): ");
                    DateTime dateTime;
                    if (DateTime.TryParse(Console.ReadLine(), out dateTime))
                    {
                        Console.Write("Enter event description: ");
                        string description = Console.ReadLine();
                        presenter.AddEvent(dateTime, description);
                    }
                    else
                    {
                        view.ShowMessage("Invalid date and time format.");
                    }
                    break;
                case "2":
                    Console.Write("Enter date to show events (yyyy-MM-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime dateToShow))
                    {
                        presenter.ShowEvents(dateToShow);
                    }
                    else
                    {
                        view.ShowMessage("Invalid date format.");
                    }
                    break;
                case "3":
                    Console.Write("Enter file path to save events: ");
                    string saveFilePath = Console.ReadLine();
                    presenter.SaveEventsToFile(saveFilePath);
                    break;
                case "4":
                    Console.Write("Enter file path to load events from: ");
                    string loadFilePath = Console.ReadLine();
                    presenter.LoadEventsFromFile(loadFilePath);
                    break;
                case "5":
                    presenter.SortEventsByDateTime();
                    break;
                case "6":
                    Console.Write("Enter start date (yyyy-MM-dd): ");
                    DateTime startDate;
                    if (DateTime.TryParse(Console.ReadLine(), out startDate))
                    {
                        Console.Write("Enter end date (yyyy-MM-dd): ");
                        DateTime endDate;
                        if (DateTime.TryParse(Console.ReadLine(), out endDate))
                        {
                            presenter.SearchEventsByDate(startDate, endDate);
                        }
                        else
                        {
                            view.ShowMessage("Invalid end date format.");
                        }
                    }
                    else
                    {
                        view.ShowMessage("Invalid start date format.");
                    }
                    break;
                case "7":
                    isRunning = false;
                    break;
                default:
                    view.ShowMessage("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
