using System;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ProEventos.API.Controllers;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.Tests.Unit.Controllers
{
    public class EventoControllersTest
    {
        private EventoController _controller;
        private DataContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            _context = new DataContext(options);

            // Adicione um evento de teste ao contexto
            var eventoTeste = new Evento
            {
                Id = 1,
                Local = "Local de Teste",
                Date = "Data de Teste",
                Theme = "Tema de Teste",
                QuantityOfPeople = 100,
                TicketTier = "Tier de Teste",
                ImageUrl = "URL de Teste"
            };

            _context.Eventos.Add(eventoTeste);
            _context.SaveChanges();

            // crie uma instância de EventoController
            _controller = new EventoController(_context);
        }



        [Test]
        public void ObterPorId_ComIdValido_RetornaEventoValido()
        {
            var expectedId = 1;

            var result = _controller.GetById(expectedId);

            Assert.IsInstanceOf<Evento>(result);
            Assert.That(result.Id, Is.EqualTo(expectedId));
        }
    }
}
