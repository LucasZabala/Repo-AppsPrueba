using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Concierto.Logic.Data;
using Concierto.Logic.Models;
using Concierto.Logic.Interfaces;

namespace Concierto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CantantesController : ControllerBase
    {
        private readonly ICantanteService _cantanteService;

        public CantantesController(ICantanteService cantanteService)
        {
            _cantanteService = cantanteService;
        }

        // GET: api/Cantantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cantante>>> GetCantantes()
        {
            var cantantes = await _cantanteService.GetAllCantantesAsync();
            return Ok(cantantes);
        }

        // GET: api/Cantantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cantante>> GetCantante(int id)
        {
            var cantante = await _cantanteService.GetByIdCantanteAsync(id);
            return Ok(cantante);
        }

        // PUT: api/Cantantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCantante(Cantante cantante)
        {
            try
            {
                await _cantanteService.UpdateCantanteAsync(cantante);
                return Ok();
            }
            catch (Exception ex)
            {
                var problemDetails = new ProblemDetails
                {

                    Title = "Error al editar cantante",
                    Detail = ex.Message,

                };
                return BadRequest(problemDetails);
            }
        }

        // POST: api/Cantantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cantante>> PostCantante(Cantante cantante)
        {
            try
            {
                await _cantanteService.AddCantanteAsync(cantante);
                return Ok();
            }
            catch (Exception ex)
            {
                var problemDetails = new ProblemDetails
                {

                    Title = "Error al agregar cantante",
                    Detail = ex.Message,

                };
                return BadRequest(problemDetails);
            }
        }

        // DELETE: api/Cantantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCantante(int id)
        {
            try
            {
                await _cantanteService.DeleteCantanteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                var problemDetails = new ProblemDetails
                {

                    Title = "Error al eliminar cantante",
                    Detail = ex.Message,

                };
                return BadRequest(problemDetails);
            }
        }

    }
}
