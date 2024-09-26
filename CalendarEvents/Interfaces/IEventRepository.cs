using System.Collections.Generic;
using CalendarEvents.Models;

namespace CalendarEvents.Interfaces;

public interface IEventsRepository
{
    void AddEvent(Event newEvent);
    IEnumerable<Event> GetAllEvents();
}