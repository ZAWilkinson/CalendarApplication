using System;
using CalendarEvents.Models;
using CalendarEvents.DTOs;
using CalendarEvents.Interfaces;
using CalendarEvents.Services;
using CalendarEvents.Repositories;

namespace CalendarEvents
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Please enter the event details in the format 'yyyy-MM-dd,hh:mm,Activity':");
            var stringinput = Console.ReadLine();

            IEventParserService parser = new EventParserService();
            IEventsRepository repository = new EventRepository();

            if (string.IsNullOrWhiteSpace(stringinput))
            {
                Console.WriteLine("Input cannot be null or empty.");
                return;
            }

            try
            {
                Event parsedEvent = parser.ParseEvent(stringinput);
                repository.AddEvent(parsedEvent);

                // Convert to DTO for output
                EventDTO eventDto = new EventDTO
                {
                    Date = parsedEvent.Date.ToString("yyyy-MM-dd"),
                    Time = parsedEvent.Time.ToString(@"hh\:mm"),
                    Activity = parsedEvent.Activity
                };

                Console.WriteLine($"Date: {eventDto.Date}");
                Console.WriteLine($"Time: {eventDto.Time}");
                Console.WriteLine($"Activity: {eventDto.Activity}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}