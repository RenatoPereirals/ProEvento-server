using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Interfaces.ContractApplication;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Services
{
    public class EventService : IEventApplication
    {
        private readonly IRepository _repository;
        private readonly IEventPersistence _eventPersistence;

        public EventService(IRepository repository, IEventPersistence eventPersistence)
        {
            _repository = repository;
            _eventPersistence = eventPersistence;
            
        }
        public async Task<Event> AddEvents(Event model)
        {
             try
            {
                _repository.Add<Event>(model);
                if (await _repository.SaveChangesAsync())
                {
                    var addedEvent = await _eventPersistence.GetEventByIdAsync(model.Id, false);
                    return addedEvent;
                }
                
                throw new Exception("Erro interno do servidor: Não foi possível adicionar o evento.");
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Erro interno do servidor: " + dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar o evento: " + ex.Message);
            }
        }

        public Task<bool> DeleteEvent(int eventId)
        {
            throw new NotImplementedException();
        }

        public Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            throw new NotImplementedException();
        }

        public Task<Event[]> GetAllEventsByThemeAsync(string Theme, bool includeSpeakers = false)
        {
            throw new NotImplementedException();
        }

        public Task<Event> GetEventByIdAsync(int EventId, bool includeSpeakers = false)
        {
            throw new NotImplementedException();
        }

        public Task<Event> UpdateEvent(int eventId, Event model)
        {
            throw new NotImplementedException();
        }
    }
}