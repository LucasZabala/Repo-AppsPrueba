using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Electronic.Logic.Data;
using Electronic.Logic.Models;

namespace Electronic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ElectronicDbContext _context;

        public CategoriasController(ElectronicDbContext context)
        {
            _context = context;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // PUT: api/Categorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoria.Id)
            {
                return BadRequest();
            }

            var categoriaToUpdate = await _context.Categorias.FindAsync(id);

            if (categoriaToUpdate == null)
            {
                return NotFound();
            }

            bool nombreDuplicado = await _context.Categorias.AnyAsync(c => c.Nombre == categoria.Nombre && c.Id != categoria.Id);
            if (nombreDuplicado)
            {
                ModelState.AddModelError("Nombre", "Ya existe otra categoría con este nombre.");
                return BadRequest(ModelState);
            }

            //_context.Entry(categoria).State = EntityState.Modified;
            categoriaToUpdate.Nombre = categoria.Nombre;

            //Si otro usuario edito la cateoria mientras yo la edite se dispara el catch
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //No devuelve nada
            // return NoContent();
            //Devuelve la categoria que se edito
            return Ok(categoria);
        }

        // POST: api/Categorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool categoriaExiste = await _context.Categorias.AnyAsync(c => c.Nombre == categoria.Nombre);
            if (categoriaExiste)
            {
                ModelState.AddModelError("Nombre", "El nombre de la categoría ya existe.");
                return BadRequest(ModelState);
            }

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            //Devuelve categoria que se agrego
            return CreatedAtAction("GetCategoria", new { id = categoria.Id }, categoria);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {

            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            var tieneProductosAsociados = await _context.Productos.AnyAsync(p => p.Categoria_Id == id);
            if (tieneProductosAsociados)
            {
                return BadRequest("No se puede eliminar la categoría porque tiene productos asociados.");
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}
