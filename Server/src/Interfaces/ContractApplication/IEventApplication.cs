using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Interfaces.ContractApplication
{
    public interface IEventApplication
    {
        Task<Event> AddEvents(Event model);
        Task<Event> UpdateEvent(int eventId, Event model);
        Task<bool> DeleteEvent(int eventId);
        Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false);
        Task<Event[]> GetAllEventsByThemeAsync(string Theme, bool includeSpeakers = false);
        Task<Event> GetEventByIdAsync(int EventId, bool includeSpeakers =false);   
    }
}