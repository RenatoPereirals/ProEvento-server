using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public interface IProeventosPersistence
    {      

        //Geral
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        void DeleteRange<T>(T[] entity) where T: class;
        Task<bool> SaveChangesAsync();

        //Eventos
        Task<Event[]> GetAllEventsByThemeAsync(string Theme, bool includeSpeakers);
        Task<Event[]> GetAllEventsAsync(bool includeSpeakers);
        Task<Event> GetEventByIdAsync(int EventId, bool includeSpeakers);

        //Speakers
        Task<Speaker[]> GetAllSpeakersByNameAsync(string Name, bool includeEvents);
        Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents);
        Task<Speaker> GetSpeakerByIdAsync(int SpeakerId, bool includeEvents);
    }
}