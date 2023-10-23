using System;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ProEventos.API.Controllers;
using ProEventos.API.Data;
using ProEventos.API.Models;
using System.Collections.Generic;
using System.Linq;

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

            // Verifique se o evento de teste com ID 1 já existe no contexto
            if (_context.Eventos.All(e => e.Id != 1))
            {
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
            }

            // Crie uma instância de EventoController
            _controller = new EventoController(_context);
        }

        [Test]
        public void GetById_ComIdValido_RetornaEventoValido()
        {
            var expectedId = 1;

            var result = _controller.GetById(expectedId);

            Assert.IsInstanceOf<Evento>(result);
            Assert.That(result.Id, Is.EqualTo(expectedId));
        }

        [Test]
        public void GetAllEvents_RetornaListaDeEventos()
        {
            var result = _controller.GetAllEvents();

            Assert.IsInstanceOf<IEnumerable<Evento>>(result);
            Assert.IsTrue(result.Any());
        }

        [Test]
        public void GetByTheme_ComTemaValido_RetornaEventoValido()
        {
            var expectedTheme = "Tema de Teste";

            var result = _controller.GetByTheme(expectedTheme);

            Assert.IsInstanceOf<Evento>(result);
            Assert.That(result.Theme, Is.EqualTo(expectedTheme));
        }

        [Test]
        public void Post_CriaNovoEvento_RetornaEventoCriado()
        {
            var novoEvento = new Evento
            {
                Local = "Novo Local",
                Date = "Nova Data",
                Theme = "Novo Tema",
                QuantityOfPeople = 50,
                TicketTier = "Nova Tier",
                ImageUrl = "Nova URL"
            };

            var result = _controller.Post(novoEvento);

            Assert.IsInstanceOf<Evento>(result);
            Assert.IsNotNull(result.Id);
        }

        [Test]
        public void Put_AtualizaEventoExistente_RetornaEventoAtualizado()
        {
            var eventoAtualizado = new Evento
            {
                Id = 1,
                Local = "Local Atualizado",
                Date = "Data Atualizada",
                Theme = "Tema Atualizado",
                QuantityOfPeople = 200,
                TicketTier = "Tier Atualizada",
                ImageUrl = "URL Atualizada"
            };

            var result = _controller.Put(1, eventoAtualizado);

            Assert.IsInstanceOf<Evento>(result);
            Assert.AreEqual(eventoAtualizado.Id, result.Id);
        }

        [Test]
        public void Delete_ExcluiEventoExistente_RetornaNenhumConteúdo()
        {
            var idParaExcluir = 1;

            var result = _controller.Delete(idParaExcluir);

            Assert.IsInstanceOf<NoContentResult>(result);
        }
    }
}
