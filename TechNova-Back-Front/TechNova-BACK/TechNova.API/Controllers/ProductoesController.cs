using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using TechNova.Logic.Data;
using TechNova.Logic.Interfaces;
using TechNova.Logic.Models;

namespace TechNova.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoesController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoesController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: api/Productoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            var productos = await _productoService.GetAllProductosAsync();
            return Ok(productos);
        }

        // GET: api/Productoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            try
            {
                var prodcuto = await _productoService.GetProductoByIdAsync(id);
                return Ok(prodcuto);
            }
            catch (InvalidOperationException ex)
            {
                //Se manda como objeto json
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex) { 
                return StatusCode(500, new { message = "Error: " + ex.Message });
            }
        }

        // PUT: api/Productoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if(id != producto.Id)
            {
                return BadRequest(new { message = "El ID de la URL no coincide con el ID del producto." });
            }
            try
            {
                await _productoService.UpdateProductoAsync(producto);
                return Ok();
            }catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error: " + ex.Message });
            }

        }

        // POST: api/Productoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
             
        }

        // DELETE: api/Productoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            
        }
        
    }
}
