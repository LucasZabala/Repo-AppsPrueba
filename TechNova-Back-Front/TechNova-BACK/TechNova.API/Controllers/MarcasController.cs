using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechNova.Logic.Data;
using TechNova.Logic.Models;
using TechNova.Logic.Services;

namespace TechNova.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly MarcaService _marcaService;

        public MarcasController(MarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        // GET: api/Marcas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marca>>> GetMarcas()
        {
            var marcas = await _marcaService.GetAllMarcasAsync();
            return Ok(marcas);
        }

        // GET: api/Marcas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetMarca(int id)
        {

            try
            {
                var marca = await _marcaService.GetMarcaByIdAsync(id);
                return Ok(marca);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error: {ex.Message}" });
            }
        }

        // PUT: api/Marcas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarca(int id, Marca marca)
        {
            if (id != marca.Id)
            {
                return BadRequest();
            }

            try
            {
                await _marcaService.UpdateMarcaAsync(marca);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error: {ex.Message}" });
            }

        }

        // POST: api/Marcas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Marca>> PostMarca(Marca marca)
        {
            try
            {
                await _marcaService.AddMarcaAsync(marca);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error: {ex.Message}" });
            }
        }

        // DELETE: api/Marcas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarca(int id)
        {
            try
            {
                await _marcaService.DeleteMarcaAsync(id);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error: {ex.Message}" });
            }
        }

    }
}
