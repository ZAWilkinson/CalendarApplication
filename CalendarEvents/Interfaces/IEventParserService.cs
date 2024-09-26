using CalendarEvents.Models;

namespace CalendarEvents.Interfaces;

public interface IEventParserService
{
    Event ParseEvent(string input);
}