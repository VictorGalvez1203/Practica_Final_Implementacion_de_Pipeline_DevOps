using CI_CD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CI_CD.Controllers
{
    public class HomeController : Controller
    {
        private readonly Datos_Productos _datosProductos;

        // Inyectar contexto y clase de datos
        public HomeController(PracticaContext context)
        {
            _datosProductos = new Datos_Productos(context); // Asegúrate de pasar el contexto aquí
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                // Recuperar los productos de la base de datos
                var productos = await _datosProductos.Mostrar();

                // Retornar la vista con la lista de productos
                return View(productos);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar productos: " + ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Guardar(Producto producto)
        {
            // Validación de los campos obligatorios
            if (string.IsNullOrEmpty(producto.Nombre) || string.IsNullOrEmpty(producto.Descripcion) || string.IsNullOrEmpty(producto.Marca))
            {
                ModelState.AddModelError("", "Los campos Nombre, Descripción y Marca son obligatorios.");
                return View(producto); // Retorna la vista con el error si no pasa la validación
            }

            // Insertar el nuevo producto
            await _datosProductos.Insertar(producto.Nombre, producto.Descripcion, producto.Marca, producto.Precio ?? 0, producto.Stock ?? 0);

            // Redirigir a la página principal después de guardar
            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            // Usamos el procedimiento almacenado para eliminar un producto de forma asincrónica
            await _datosProductos.Eliminar(id);
            return RedirectToAction("Index"); // Redirigir a la página principal después de eliminar
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Producto producto)
        {
            // Validación básica de los campos
            if (string.IsNullOrEmpty(producto.Nombre) || string.IsNullOrEmpty(producto.Descripcion) || string.IsNullOrEmpty(producto.Marca))
            {
                ModelState.AddModelError("", "Los campos Nombre, Descripción y Marca son obligatorios.");
                return View(producto); // Retorna la vista con el error si no pasa la validación
            }

            try
            {
                // Llamar al método Editar de Datos_Productos para actualizar el producto
                await _datosProductos.Editar(producto.Id, producto.Nombre, producto.Descripcion, producto.Marca, producto.Precio ?? 0, producto.Stock ?? 0);

                // Redirigir a la página principal después de editar
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Si ocurre un error durante la edición, añadir el error al ModelState
                ModelState.AddModelError("", "Error al editar el producto: " + ex.Message);
                return View(producto); // Retorna la vista con el error
            }
        }


    }
}
