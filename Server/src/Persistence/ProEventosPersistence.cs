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

        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.TicketTiers)
                .Include(e => e.SocialMedias);
            
            query = query.OrderBy(e => e.Id)
                         .Where(e => e.Id == eventId);

            if(includeSpeakers)
            {
                query = query
                    .Include(e => e.SpeakersEvents)
                    .ThenInclude(sp => sp.Speaker);
            }

            return await query.FirstOrDefaultAsync() ?? new Event();
        }

        //Speakers
        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(s => s.SocialMedias);
            
            query = query.OrderBy(s => s.Id);
            
            if(includeEvents)
            {
                query = query
                    .Include(s => s.SpeakersEvents)
                    .ThenInclude(sp => sp.Event);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents)
        {
           IQueryable<Speaker> query = _context.Speakers
                .Include(s => s.SocialMedias);
            
            query = query.OrderBy(s => s.Id)
                         .Where(p => p.Name.ToLower()
                         .Contains(name.ToLower()));
            
            if(includeEvents)
            {
                query = query
                    .Include(s => s.SpeakersEvents)
                    .ThenInclude(sp => sp.Event);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvents)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(s => s.SocialMedias);
            
            query = query.OrderBy(s => s.Id)
                         .Where(p => p.Id == speakerId);
            
            if(includeEvents)
            {
                query = query
                    .Include(s => s.SpeakersEvents)
                    .ThenInclude(sp => sp.Event);
            }

            return await query.FirstOrDefaultAsync() ?? new Speaker();
        }
    }
}