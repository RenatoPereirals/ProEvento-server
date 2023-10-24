using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string Local { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public string Theme { get; set; }  = string.Empty;    
        public int QuantityOfPeople { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;   
        public string Email { get; set; } = string.Empty;   
        public required IEnumerable<TicketTier> TicketTiers { get; set; }
        public required IEnumerable<SocialMedia> SocialMedias { get; set; }
        public required IEnumerable<SpeakerEvent> SpeakersEvents { get; set; }
    }
}