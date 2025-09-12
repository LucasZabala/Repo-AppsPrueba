using Concierto.Logic.Data;
using Concierto.Logic.Interfaces;
using Concierto.Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concierto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoesController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventoesController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        // GET: api/Eventoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventoes()
        {
            var eventos = await _eventoService.GetAllEventosAsync();
            return Ok(eventos);
        }

        // GET: api/Eventoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            var evento = await _eventoService.GetByIdEventoAsync(id);
            return Ok(evento);
        }

        // PUT: api/Eventoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(Evento evento)
        {
            try
            {
                await _eventoService.UpdateEventoAsync(evento);
                return Ok();
            }
            catch (Exception ex)
            {
                // Devolvemos un objeto ProblemDetails para una respuesta JSON estructurada
                var problemDetails = new ProblemDetails
                {

                    Title = "Error al editar evento",
                    Detail = ex.Message,

                };
                return BadRequest(problemDetails);
            }

        }

        // POST: api/Eventoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Evento>> PostEvento(Evento evento)
        {
            try
            {
                await _eventoService.AddEventoAsync(evento);
                return Ok();
            }
            catch (Exception ex)
            {

                var problemDetails = new ProblemDetails
                {

                    Title = "Error al agregar evento",
                    Detail = ex.Message,

                };
                return BadRequest(problemDetails);
            }
        }

        // DELETE: api/Eventoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            try
            {
                await _eventoService.DeleteEventoAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                var problemDetails = new ProblemDetails
                {

                    Title = "Error al eliminar evento",
                    Detail = ex.Message,

                };
                return BadRequest(problemDetails);
            }
        }
    }
}
