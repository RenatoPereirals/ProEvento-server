using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public interface ISpeakerPersistence
    { 
        Task<Speaker[]> GetAllSpeakersByNameAsync(string Name, bool includeEvents);
        Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents);
        Task<Speaker> GetSpeakerByIdAsync(int SpeakerId, bool includeEvents);
    }
}