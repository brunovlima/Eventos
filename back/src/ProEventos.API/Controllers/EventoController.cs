using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Data;
using ProEventos.API.Models;
using System.Linq;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("Evento")]
    public class EventoController : ControllerBase
    
    {
        private readonly DataContext _context;

        public EventoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var eventos = _context.Eventos.ToList();
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var evento = _context.Eventos.FirstOrDefault(e => e.EventoId == id);
            if (evento == null)
            {
                return NotFound("Evento não encontrado");
            }
            return Ok(evento);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Evento evento)
        {
            _context.Eventos.Add(evento);
            _context.SaveChanges();
            return Ok(evento);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Evento eventoAtualizado)
        {
            var evento = _context.Eventos.FirstOrDefault(e => e.EventoId == id);
            if (evento == null)
            {
                return NotFound("Evento não encontrado");
            }

            evento.Tema = eventoAtualizado.Tema;
            evento.Local = eventoAtualizado.Local;
            evento.DataEvento = eventoAtualizado.DataEvento;
            evento.QtdPessoas = eventoAtualizado.QtdPessoas;
            evento.Lote = eventoAtualizado.Lote;
            evento.ImagemURL = eventoAtualizado.ImagemURL;

            _context.SaveChanges();
            return Ok(evento);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var evento = _context.Eventos.FirstOrDefault(e => e.EventoId == id);
            if (evento == null)
            {
                return NotFound("Evento não encontrado");
            }

            _context.Eventos.Remove(evento);
            _context.SaveChanges();
            return Ok("Evento removido com sucesso");
        }
    }
}
