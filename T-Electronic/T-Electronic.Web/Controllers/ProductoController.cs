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

        // El constructor recibe las implementaciones de los servicios.
        // El sistema de inyección de dependencias de ASP.NET se encarga de esto automáticamente.
        public ProductoController(IProductoService productoService, ICategoriaService categoriaService)
        {
            _productoService = productoService;
            _categoriaService = categoriaService;
        }

        // GET: Producto/Index
        // Muestra la lista completa de productos.
        // Es un método asíncrono para no bloquear el hilo principal mientras se obtienen los datos.
        public async Task<IActionResult> Index()
        {
            // Llama al servicio para obtener todos los productos de forma asíncrona.
            var productos = await _productoService.GetAllProductosAsync();
            // Retorna la vista "Index.cshtml" y le pasa la lista de productos como modelo.
            return View(productos);
        }

        // GET: Producto/Details/5
        // Muestra los detalles de un producto específico, identificado por su ID.
        public async Task<IActionResult> Details(int id)
        {
            // Busca un producto por ID de forma asíncrona.
            var producto = await _productoService.GetProductoByIdAsync(id);
            // Si el producto no se encuentra, retorna una respuesta 404.
            if (producto == null)
            {
                return NotFound();
            }
            // Si lo encuentra, retorna la vista "Details.cshtml" con el producto como modelo.
            return View(producto);
        }

        // GET: Producto/Create
        // Muestra el formulario para crear un nuevo producto.
        public async Task<IActionResult> Create()
        {
            // Obtiene la lista de categorías para llenar un menú desplegable en el formulario.
            // Se usa ViewBag para pasar datos adicionales a la vista sin modificar el modelo principal.
            ViewBag.Categorias = await _categoriaService.GetAllCategoriasAsync();
            // Retorna la vista "Create.cshtml" que contiene el formulario.
            return View();
        }

        // POST: Producto/Create
        // Procesa los datos enviados desde el formulario de creación.
        // El atributo [HttpPost] lo diferencia del método GET.
        // [ValidateAntiForgeryToken] previene ataques de falsificación de solicitudes.
        public async Task<IActionResult> Create(Producto producto)
        {
            // Comprueba si los datos del modelo son válidos según las anotaciones de datos (ej. [Required]).
            if (ModelState.IsValid)
            {
                // Llama al servicio para agregar el nuevo producto a la base de datos.
                await _productoService.AddProductoAsync(producto);
                // Redirige al usuario a la página de la lista de productos después de la creación exitosa.
                return RedirectToAction(nameof(Index));
            }
            // Si hay errores de validación, vuelve a cargar las categorías y retorna la vista con los datos enviados.
            ViewBag.Categorias = await _categoriaService.GetAllCategoriasAsync();
            return View(producto);
        }

        // GET: Producto/Edit/5
        // Muestra el formulario para editar un producto existente.
        public async Task<IActionResult> Edit(int id)
        {
            // Busca el producto a editar.
            var producto = await _productoService.GetProductoByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            // Carga las categorías y retorna la vista "Edit.cshtml" con los datos del producto.
            ViewBag.Categorias = await _categoriaService.GetAllCategoriasAsync();
            return View(producto);
        }

        // POST: Producto/Edit/5
        // Procesa los datos enviados desde el formulario de edición.
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            // Verifica que el ID en la URL coincida con el ID del objeto enviado.
            if (id != producto.Id)
            {
                return NotFound();
            }

            // Si el modelo es válido, actualiza el producto.
            if (ModelState.IsValid)
            {
                await _productoService.UpdateProductoAsync(producto);
                return RedirectToAction(nameof(Index));
            }
            // Si falla la validación, retorna a la vista para que el usuario corrija los errores.
            ViewBag.Categorias = await _categoriaService.GetAllCategoriasAsync();
            return View(producto);
        }

        // GET: Producto/Delete/5
        // Muestra la página de confirmación para eliminar un producto.
        public async Task<IActionResult> Delete(int id)
        {
            // Busca el producto para mostrar sus detalles en la página de confirmación.
            var producto = await _productoService.GetProductoByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        // Procesa la solicitud para eliminar el producto después de la confirmación.
        // [ActionName("Delete")] se usa para enlazar este método con la acción "Delete" en las vistas.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Llama al servicio para eliminar el producto.
            await _productoService.DeleteProductoAsync(id);
            // Redirige al usuario a la lista de productos.
            return RedirectToAction(nameof(Index));
        }

    }
}
