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
    public class LugarsController : ControllerBase
    {
        private readonly ILugarService _lugarService;

        public LugarsController(ILugarService lugarService)
        {
            _lugarService = lugarService;
        }

        // GET: api/Lugars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lugar>>> GetLugars()
        {
            var lugars = await _lugarService.GetAllLugaresAsync();
            return Ok(lugars);
        }

        // GET: api/Lugars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lugar>> GetLugar(int id)
        {
            var lugar = await _lugarService.GetByIdLugarAsync(id);
            return Ok(lugar);
        }

        // PUT: api/Lugars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLugar(Lugar lugar)
        {
            try
            {
                await _lugarService.UpdateLugarAsync(lugar);
                return Ok();
            }
            catch (Exception ex)
            {
                // Devolvemos un objeto ProblemDetails para una respuesta JSON estructurada
                var problemDetails = new ProblemDetails
                {

                    Title = "Error al editar lugar",
                    Detail = ex.Message,

                };
                return BadRequest(problemDetails);
            }

        }

        // POST: api/Lugars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lugar>> PostLugar(Lugar lugar)
        {
            try
            {
                await _lugarService.AddLugarAsync(lugar);
                return Ok();
            }
            catch (Exception ex)
            {

                var problemDetails = new ProblemDetails
                {

                    Title = "Error al agregar lugar",
                    Detail = ex.Message,

                };
                return BadRequest(problemDetails);
            }
        }

        // DELETE: api/Lugars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLugar(int id)
        {
            try
            {
                await _lugarService.DeleteLugarAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                var problemDetails = new ProblemDetails
                {

                    Title = "Error al eliminar lugar",
                    Detail = ex.Message,

                };
                return BadRequest(problemDetails);
            }
        }
    }
}
