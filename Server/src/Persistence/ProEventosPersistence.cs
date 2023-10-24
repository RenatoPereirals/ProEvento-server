using Domain;

namespace Persistence
{
    public class ProEventosPersistence : IProeventosPersistence
    {
        private readonly ProEventosContext _context;
        public ProEventosPersistence(ProEventosContext context)
        {
            _context = context;
            
        }
        
        //Geral
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void DeleteRange<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }  

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        //Events
        public Task<Event[]> GetAllEventsAsync(bool includeSpeakers)
        {
            throw new NotImplementedException();
        }

        public Task<Event[]> GetAllEventsByThemeAsync(string Theme, bool includeSpeakers)
        {
            throw new NotImplementedException();
        }

        public Task<Event> GetEventByIdAsync(int EventId, bool includeSpeakers)
        {
            throw new NotImplementedException();
        }

        //Speakers
        public Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents)
        {
            throw new NotImplementedException();
        }

        public Task<Speaker[]> GetAllSpeakersByNameAsync(string Name, bool includeEvents)
        {
            throw new NotImplementedException();
        }

        public Task<Speaker> GetSpeakerByIdAsync(int SpeakerId, bool includeEvents)
        {
            throw new NotImplementedException();
        }
    }
}