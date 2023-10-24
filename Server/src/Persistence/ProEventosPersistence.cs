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
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
           _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }  

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0; 
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