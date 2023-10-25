using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public interface IEventPersist
    {  
        Task<Event[]> GetAllEventsByThemeAsync(string Theme, bool includeSpeakers);
        Task<Event[]> GetAllEventsAsync(bool includeSpeakers);
        Task<Event> GetEventByIdAsync(int EventId, bool includeSpeakers);   
    }
}