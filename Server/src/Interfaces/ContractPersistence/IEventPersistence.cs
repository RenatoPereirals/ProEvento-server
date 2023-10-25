using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public interface IEventPersistence
    {  
        Task<Event[]> GetAllEventsByThemeAsync(string Theme, bool includeSpeakers = false);
        Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false);
        Task<Event> GetEventByIdAsync(int EventId, bool includeSpeakers = false);   
    }
}