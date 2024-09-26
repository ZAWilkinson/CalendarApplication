using System;
using CalendarEvents.Interfaces;
using CalendarEvents.Models;

namespace CalendarEvents.Services
{
    public class EventParserService : IEventParserService
    {
        public Event ParseEvent(string input)
        {
            // Expected format: yyyy-MM-dd,hh:mm,Activity
            var parts = input.Split(',');

            if (parts.Length != 3)
            {
                throw new ArgumentException("Input must be in the format 'yyyy-MM-dd,hh:mm,Activity'.");
            }

            DateTime date;
            if (!DateTime.TryParse(parts[0], out date))
            {
                throw new ArgumentException("Invalid date format. Use yyyy-MM-dd.");
            }

            TimeSpan time;
            if (!TimeSpan.TryParse(parts[1], out time))
            {
                throw new ArgumentException("Invalid time format. Use hh:mm.");
            }

            string activity = parts[2];

            return new Event
            {
                Date = date,
                Time = time,
                Activity = activity
            };
        }
    }
}