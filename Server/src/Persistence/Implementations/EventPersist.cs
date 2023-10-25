using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public class EventPersist : IEventPersistence
    {
        private readonly ProEventosContext _context;
        public EventPersist(ProEventosContext context)
        {
            _context = context;
            
        }
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

    }
}