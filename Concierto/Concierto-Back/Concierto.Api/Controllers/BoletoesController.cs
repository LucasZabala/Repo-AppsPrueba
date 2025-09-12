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
    public class BoletoesController : ControllerBase
    {
        private readonly IBoletoService _boletoService;

        public BoletoesController(IBoletoService boletoService)
        {
            _boletoService = boletoService;
        }

        // GET: api/Boletoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boleto>>> GetBoletoes()
        {
            var boletos = await _boletoService.GetAllBoletosAsync();
            return Ok(boletos);
        }

        // GET: api/Boletoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Boleto>> GetBoleto(int id)
        {
            var boleto = await _boletoService.GetByIdBoletoAsync(id);
            return Ok(boleto);
        }

        // PUT: api/Boletoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoleto(Boleto boleto)
        {
            try
            {
                await _boletoService.UpdateBoletoAsync(boleto);
                return Ok();
            }
            catch (Exception ex)
            {
                // Devolvemos un objeto ProblemDetails para una respuesta JSON estructurada
                var problemDetails = new ProblemDetails
                {

                    Title = "Error al editar boleto",
                    Detail = ex.Message,

                };
                return BadRequest(problemDetails);
            }

        }

        // POST: api/Boletoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Boleto>> PostBoleto(Boleto boleto)
        {
            try
            {
                await _boletoService.AddBoletoAsync(boleto);
                return Ok();
            }
            catch (Exception ex)
            {

                var problemDetails = new ProblemDetails
                {

                    Title = "Error al agregar boleto",
                    Detail = ex.Message,

                };
                return BadRequest(problemDetails);
            }
        }

        // DELETE: api/Boletoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoleto(int id)
        {
            try
            {
                await _boletoService.DeleteBoletoAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                var problemDetails = new ProblemDetails
                {

                    Title = "Error al eliminar boleto",
                    Detail = ex.Message,

                };
                return BadRequest(problemDetails);
            }
        }
    }
}
