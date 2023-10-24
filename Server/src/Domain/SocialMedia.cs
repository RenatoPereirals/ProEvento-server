namespace Domain
{
    public class SocialMedia
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public int EventId { get; set; }
        public Event? Event { get; set; }
        public int SpeakerId { get; set; }
        public Speaker? Speaker { get; set; }
    }
}