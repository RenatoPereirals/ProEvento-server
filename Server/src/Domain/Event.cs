using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string? Local { get; set; }
        public DateTime? Date { get; set; }
        public string? Theme { get; set; }    
        public int QuantityOfPeople { get; set; }
        public string? ImageUrl { get; set; }
        public string? Phone { get; set; }   
        public string? Email { get; set; }   
        public IEnumerable<TicketTier>? TicketTiers { get; set; }
        public IEnumerable<SocialMedia>? SocialMedias { get; set; }
        public IEnumerable<SpeakerEvent>? SpeakersEvents { get; set; }
    }
}