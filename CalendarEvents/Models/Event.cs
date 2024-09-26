using System;

namespace CalendarEvents.Models
{
    public class Event
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Activity { get; set; }
    }
}