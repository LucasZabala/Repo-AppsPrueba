using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using T_Electronic.Logic.Interfaces;
using T_Electronic.Logic.Models;

namespace T_Electronic.Web.Controllers
{
    public class ProductoController : Controller
    {
        // Campos privados para la inyección de dependencias de los servicios.
        private readonly IProductoService _productoService;
        private readonly ICategoriaService _categoriaService;
        public ProductoController(IProductoService productoService, ICategoriaService categoriaService)
        {
            _productoService = productoService;
            _categoriaService = categoriaService;
        }

        // GET: Producto/Index
        public async Task<IActionResult> Index()
        {
            var productos = await _productoService.GetAllProductosAsync();
            return View(productos);
        }

        // GET: Producto/Details/5
        public async Task<IActionResult> Details(int id)
        {
            // Busca un producto por ID de forma asíncrona.
            var producto = await _productoService.GetProductoByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // GET: Producto/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categorias = await _categoriaService.GetAllCategoriasAsync();
            return View();
        }

        // POST: Producto/Create
        public async Task<IActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                await _productoService.AddProductoAsync(producto);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorias = await _categoriaService.GetAllCategoriasAsync();
            return View(producto);
        }

        // GET: Producto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            // Busca el producto a editar.
            var producto = await _productoService.GetProductoByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewBag.Categorias = await _categoriaService.GetAllCategoriasAsync();
            return View(producto);
        }

        // POST: Producto/Edit/5
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _productoService.UpdateProductoAsync(producto);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorias = await _categoriaService.GetAllCategoriasAsync();
            return View(producto);
        }

        // GET: Producto/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _productoService.GetProductoByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productoService.DeleteProductoAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
