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
    public class AsientoesController : ControllerBase
    {
        private readonly IAsientoService _asientoService;

        public AsientoesController(IAsientoService asientoService)
        {
            _asientoService = asientoService;
        }

        // GET: api/Asientoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asiento>>> GetAsientoes()
        {
            var asientos = await _asientoService.GetAllAsientosAsync();
            return Ok(asientos);
        }

        // GET: api/Asientoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asiento>> GetAsiento(int id)
        {
            var asiento = await _asientoService.GetByIdAsientoAsync(id);
            return Ok(asiento);
        }

        // PUT: api/Asientoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsiento(Asiento asiento)
        {
            try
            {
                await _asientoService.UpdateAsientoAsync(asiento);
                return Ok();
            }
            catch (Exception ex)
            {
                // Devolvemos un objeto ProblemDetails para una respuesta JSON estructurada
                var problemDetails = new ProblemDetails
                {

                    Title = "Error al editar asiento",
                    Detail = ex.Message,

                };
                return BadRequest(problemDetails);
            }

        }

        // POST: api/Asientoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Asiento>> PostAsiento(Asiento asiento)
        {
            try
            {
                await _asientoService.AddAsientoAsync(asiento);
                return Ok();
            }
            catch (Exception ex)
            {

                var problemDetails = new ProblemDetails
                {

                    Title = "Error al agregar asiento",
                    Detail = ex.Message,

                };
                return BadRequest(problemDetails);
            }
        }

        // DELETE: api/Asientoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsiento(int id)
        {
            try
            {
                await _asientoService.DeleteAsientoAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                var problemDetails = new ProblemDetails
                {

                    Title = "Error al eliminar asiento",
                    Detail = ex.Message,

                };
                return BadRequest(problemDetails);
            }
        }
    }
}
