using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence;
    public class ProEventosContext : DbContext 
    {
        
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) 
        { 
        }

        public DbSet<Event>? Events { get; set; }
        public DbSet<TicketTier>? TicketTiers { get; set; }
        public DbSet<SocialMedia>? SocialMedias { get; set; }
        public DbSet<Speaker>? Speakers { get; set; }
        public DbSet<SpeakerEvent>? SpeakersEvents { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpeakerEvent>().HasKey(SP => new {SP.EventId, SP.SpeakerId});  
        }
    }
    