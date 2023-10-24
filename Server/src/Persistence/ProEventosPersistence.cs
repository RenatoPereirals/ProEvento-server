using Domain;
using Microsoft.EntityFrameworkCore;

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
        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.TicketTiers)
                .Include(e => e.SocialMedias);
            
            query = query.OrderBy(e => e.Id);
            
            if(includeSpeakers)
            {
                query = query
                    .Include(e => e.SpeakersEvents)
                    .ThenInclude(sp => sp.Speaker);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
           IQueryable<Event> query = _context.Events
                .Include(e => e.TicketTiers)
                .Include(e => e.SocialMedias);
            
            query = query.OrderBy(e => e.Id)
                         .Where(e => e.Theme.ToLower()
                         .Contains(theme.ToLower()));

            if(includeSpeakers)
            {
                query = query
                    .Include(e => e.SpeakersEvents)
                    .ThenInclude(sp => sp.Speaker);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Event> GetEventByIdAsync(int EventId, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.TicketTiers)
                .Include(e => e.SocialMedias);
            
            query = query.OrderBy(e => e.Id)
                         .Where(e => e.Id == EventId);

            if(includeSpeakers)
            {
                query = query
                    .Include(e => e.SpeakersEvents)
                    .ThenInclude(sp => sp.Speaker);
            }

            return await query.FirstOrDefaultAsync() ?? new Event();
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