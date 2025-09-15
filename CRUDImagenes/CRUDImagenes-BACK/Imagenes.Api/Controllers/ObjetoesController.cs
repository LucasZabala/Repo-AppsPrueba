using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Imagenes.Logic.Data;
using Imagenes.Logic.Models;
using Imagenes.Logic.Interface;

namespace Imagenes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetoesController : ControllerBase
    {
        private readonly IObjetoService _objetoService;

        public ObjetoesController(IObjetoService objetoService)
        {
            _objetoService = objetoService;
        }

        // GET: api/Objetoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Objeto>>> GetObjetos()
        {
            var objetos = await _objetoService.GetAllObjetosAsync();
            return Ok(objetos);

        }

        // GET: api/Objetoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Objeto>> GetObjeto(int id)
        {
            var objeto = await _objetoService.GetByIdObjetoAsync(id);

            if (objeto == null)
            {
                return NotFound();
            }

            return Ok(objeto);
        }
    }
}
