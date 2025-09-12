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
    public class AdministradorsController : ControllerBase
    {
        private readonly IAdministradorService _administradorService;

        public AdministradorsController(IAdministradorService administradorService)
        {
            _administradorService = administradorService;
        }

        // GET: api/Administradors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrador>>> GetAdministradores()
        {
            var administradores = await _administradorService.GetAllAdministradoresAsync();
            return Ok(administradores);
        }

        // GET: api/Administradors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrador>> GetAdministrador(int id)
        {
            var administrador = await _administradorService.GetByIdAdministradorAsync(id);
            return Ok(administrador);
        }

        // PUT: api/Administradors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrador(Administrador administrador)
        {
            try
            {
                await _administradorService.UpdateAdministradorAsync(administrador);
                return Ok();
            }
            catch (Exception ex)
            {
                // Devolvemos un objeto ProblemDetails para una respuesta JSON estructurada
                var problemDetails = new ProblemDetails
                {

                    Title = "Error al editar administrador",
                    Detail = ex.Message,

                };
                return BadRequest(problemDetails);
            }

        }

        // POST: api/Administradors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Administrador>> PostAdministrador(Administrador administrador)
        {
            try
            {
                await _administradorService.AddAdministradorAsync(administrador);
                return Ok();
            }
            catch (Exception ex)
            {

                var problemDetails = new ProblemDetails
                {

                    Title = "Error al agregar administrador",
                    Detail = ex.Message,

                };
                return BadRequest(problemDetails);
            }
        }

        // DELETE: api/Administradors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrador(int id)
        {
            try
            {
                await _administradorService.DeleteAdministradorAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                var problemDetails = new ProblemDetails
                {

                    Title = "Error al eliminar administrador",
                    Detail = ex.Message,

                };
                return BadRequest(problemDetails);
            }
        }

    }
}
