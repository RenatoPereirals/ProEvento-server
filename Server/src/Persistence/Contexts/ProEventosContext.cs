using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence;
    public class ProEventosContext : DbContext
    {
        
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) 
        { 
        }

        public DbSet<Event> Events => Set<Event>();
        public DbSet<TicketTier> TicketTiers => Set<TicketTier>();
        public DbSet<SocialMedia> SocialMedias => Set<SocialMedia>();
        public DbSet<Speaker> Speakers => Set<Speaker>();
        public DbSet<SpeakerEvent> SpeakersEvents => Set<SpeakerEvent>();
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpeakerEvent>().HasKey(SP => new {SP.EventId, SP.SpeakerId});  
        }
    }
    