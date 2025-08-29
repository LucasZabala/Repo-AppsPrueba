using Microsoft.AspNetCore.Mvc;
using T_Electronic.Logic.Interfaces;
using T_Electronic.Logic.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace T_Electronic.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        // El constructor usa inyección de dependencias para obtener una instancia del servicio de categoría.
        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // GET: Categoria/Index
        // Muestra una lista de todas las categorías.
        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.GetAllCategoriasAsync();
            return View(categorias);
        }

        // GET: Categoria/Details/5
        // Muestra los detalles de una categoría específica.
        public async Task<IActionResult> Details(int id)
        {
            var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // GET: Categoria/Create
        // Muestra el formulario para crear una nueva categoría.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // Procesa el formulario de creación.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaService.AddCategoriaAsync(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categoria/Edit/5
        // Muestra el formulario para editar una categoría existente.
        public async Task<IActionResult> Edit(int id)
        {
            var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Edit/5
        // Procesa el formulario de edición.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _categoriaService.UpdateCategoriaAsync(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categoria/Delete/5
        // Muestra la página de confirmación para eliminar una categoría.
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Delete/5
        // Elimina la categoría después de la confirmación.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoriaService.DeleteCategoriaAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}