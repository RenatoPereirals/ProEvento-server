using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class SpeakerPersist : ISpeakerPersist
    {
        private readonly ProEventosContext _context;
        public SpeakerPersist(ProEventosContext context)
        {
            _context = context;
            
        }
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