using System;
using CalendarEvents.Models;
using CalendarEvents.DTOs;
using CalendarEvents.Interfaces;
using CalendarEvents.Services;
using CalendarEvents.Repositories;

namespace CalendarEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the event details in the format 'yyyy-MM-dd,hh:mm,Activity':");
            string input = Console.ReadLine();

            IEventParserService parser = new EventParserService();
            IEventsRepository repository = new EventRepository();

            try
            {
                Event parsedEvent = parser.ParseEvent(input);
                repository.AddEvent(parsedEvent);

                // Convert to DTO for output
                EventDTO eventDTO = new EventDTO
                {
                    Date = parsedEvent.Date.ToString("yyyy-MM-dd"),
                    Time = parsedEvent.Time.ToString(@"hh\:mm"),
                    Activity = parsedEvent.Activity
                };

                Console.WriteLine($"Date: {eventDTO.Date}");
                Console.WriteLine($"Time: {eventDTO.Time}");
                Console.WriteLine($"Activity: {eventDTO.Activity}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}