using System.ComponentModel.DataAnnotations;

namespace Domain;

    public class Event
    {
        public Event()
        {
            SpeakersEvents = new List<SpeakerEvent>();
        }
        public int Id { get; set; }
        public string Local { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public string Theme { get; set; }  = string.Empty;    
        public int QuantityOfPeople { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;   
        public string Email { get; set; } = string.Empty;   
        public IEnumerable<TicketTier>? TicketTiers  { get; set; }
        public IEnumerable<SocialMedia>? SocialMedias  { get; set; }
        public IEnumerable<SpeakerEvent> SpeakersEvents  { get; set; }
    }
