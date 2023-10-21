namespace ProEventos.API.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string Date { get; set; }
        public string? Theme { get; set; }    
        public int QuantityOfPeople { get; set; }
        public string? TicketTier { get; set; }
        public string? ImageUrl { get; set; }
    }
}