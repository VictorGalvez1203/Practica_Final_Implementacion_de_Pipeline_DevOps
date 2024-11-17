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
            _datosProductos = new Datos_Productos(context); // Aseg�rate de pasar el contexto aqu�
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
            // Validaci�n de los campos obligatorios
            if (string.IsNullOrEmpty(producto.Nombre) || string.IsNullOrEmpty(producto.Descripcion) || string.IsNullOrEmpty(producto.Marca))
            {
                ModelState.AddModelError("", "Los campos Nombre, Descripci�n y Marca son obligatorios.");
                return View(producto); // Retorna la vista con el error si no pasa la validaci�n
            }

            // Insertar el nuevo producto
            await _datosProductos.Insertar(producto.Nombre, producto.Descripcion, producto.Marca, producto.Precio ?? 0, producto.Stock ?? 0);

            // Redirigir a la p�gina principal despu�s de guardar
            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            // Usamos el procedimiento almacenado para eliminar un producto de forma asincr�nica
            await _datosProductos.Eliminar(id);
            return RedirectToAction("Index"); // Redirigir a la p�gina principal despu�s de eliminar
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
            // Validaci�n b�sica de los campos
            if (string.IsNullOrEmpty(producto.Nombre) || string.IsNullOrEmpty(producto.Descripcion) || string.IsNullOrEmpty(producto.Marca))
            {
                ModelState.AddModelError("", "Los campos Nombre, Descripci�n y Marca son obligatorios.");
                return View(producto); // Retorna la vista con el error si no pasa la validaci�n
            }

            try
            {
                // Llamar al m�todo Editar de Datos_Productos para actualizar el producto
                await _datosProductos.Editar(producto.Id, producto.Nombre, producto.Descripcion, producto.Marca, producto.Precio ?? 0, producto.Stock ?? 0);

                // Redirigir a la p�gina principal despu�s de editar
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Si ocurre un error durante la edici�n, a�adir el error al ModelState
                ModelState.AddModelError("", "Error al editar el producto: " + ex.Message);
                return View(producto); // Retorna la vista con el error
            }
        }


    }
}
