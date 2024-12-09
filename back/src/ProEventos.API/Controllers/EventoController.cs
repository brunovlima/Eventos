using Microsoft.AspNetCore.Mvc; 
using ProEventos.API.Models; 
using System.Collections.Generic;
using System.Linq;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("Evento")]
    public class EventoController : ControllerBase
    {
        private List<Evento> eventos = new List<Evento>
        {
            new Evento
            {
                EventoId = 1,
                Tema = "Angular",
                Local = "Belo Horizonte",
                Lote = "1º Lote",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString(),
                ImagemURL = "foto.jpg"
            },
            new Evento
            {
                EventoId = 2,
                Tema = "Angular e .NET",
                Local = "São Paulo",
                Lote = "1º Lote",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(3).ToString(),
                ImagemURL = "foto2.jpg"
            }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var evento = eventos.FirstOrDefault(e => e.EventoId == id);
            if (evento == null)
            {
                return NotFound("Evento não encontrado");
            }
            return Ok(evento);
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("exemplo de post");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok($"exemplo de put com id = {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"exemplo de delete com id = {id}");
        }
    }
}
