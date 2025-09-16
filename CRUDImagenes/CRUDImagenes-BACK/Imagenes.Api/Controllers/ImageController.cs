using Imagenes.Logic.Interface;
using Imagenes.Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Imagenes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IObjetoService _objetoService;

        public ImageController(IWebHostEnvironment hostingEnvironment, IObjetoService objetoService)
        {
            _hostingEnvironment = hostingEnvironment;
            _objetoService = objetoService;
        }

        // POST: api/Image/upload
        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file, [FromForm] string titulo, [FromForm]string descripcion)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("El archivo o el título no son válidos.");
            }

            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var newObjeto = new Objeto
            {
                Titulo = titulo,
                Descripcion = descripcion,
                URLImg = uniqueFileName,
            };
            await _objetoService.AddObjetoAsync(newObjeto);

            return Ok(new { message = "Imagen y registro creados con éxito", fileName = uniqueFileName });
        }

        // PUT: api/Image/edit
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditImage(int id, [FromForm] IFormFile newFile, [FromForm] string titulo, [FromForm] string descripcion)
        {
            var objetoToUpdate = await _objetoService.GetByIdObjetoAsync(id);
            if (objetoToUpdate == null)
            {
                return NotFound("No se encontró el objeto.");
            }

            if (newFile == null || newFile.Length == 0)
            {
                return BadRequest("No se ha seleccionado un nuevo archivo.");
            }

            // 1. Eliminar el archivo antiguo del servidor
            string oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", objetoToUpdate.URLImg);
            if (System.IO.File.Exists(oldFilePath))
            {
                System.IO.File.Delete(oldFilePath);
            }

            // 2. Guardar el nuevo archivo
            string uniqueNewFileName = Guid.NewGuid().ToString() + Path.GetExtension(newFile.FileName);
            string newFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", uniqueNewFileName);

            using (var fileStream = new FileStream(newFilePath, FileMode.Create))
            {
                await newFile.CopyToAsync(fileStream);
            }

            // 3. Actualizar el nombre en la base de datos
            objetoToUpdate.URLImg = uniqueNewFileName;
            objetoToUpdate.Titulo = titulo;
            objetoToUpdate.Descripcion = descripcion;
            await _objetoService.UpdateObjetoAsync(objetoToUpdate);

            return Ok(new { message = "Imagen y registro actualizados con éxito", newFileName = uniqueNewFileName });
        }

        // DELETE: api/Image/delete/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var objetoToDelete = await _objetoService.GetByIdObjetoAsync(id);
            if (objetoToDelete == null)
            {
                return NotFound("No se encontró el objeto.");
            }

            // 1. Eliminar el archivo físico de la carpeta
            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", objetoToDelete.URLImg);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            // 2. Eliminar el registro de la base de datos
            await _objetoService.DeleteObjetoAsync(id);

            return Ok(new { message = "Imagen y registro eliminados con éxito" });
        }
    }
}
