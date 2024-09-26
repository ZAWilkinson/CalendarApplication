using System.Collections.Generic;
using CalendarEvents.Models;
using CalendarEvents.Interfaces;

namespace CalendarEvents.Repositories;

public class EventRepository : IEventsRepository
{
    private List<Event> events = new List<Event>();

    public void AddEvent(Event newEvent)
    {
        events.Add(newEvent);
    }

    public IEnumerable<Event> GetAllEvents()
    {
        return events;
    }
}