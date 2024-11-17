using CI_CD.Models;
using Microsoft.EntityFrameworkCore;

namespace CI_CD.Controllers
{
    public class Datos_Productos
    {
        private readonly PracticaContext _context;

        // Constructor donde se inyecta el contexto de la base de datos
        public Datos_Productos(PracticaContext context)
        {
            _context = context;
        }

        // Método para mostrar los productos de manera asincrónica
        public async Task<List<Producto>> Mostrar()
        {
            try
            {
                // Obtener todos los productos de la base de datos de forma asincrónica
                var productos = await _context.Productos.ToListAsync();
                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar productos: " + ex.Message);
            }
        }

        // Método para insertar un nuevo producto de manera asincrónica
        public async Task Insertar(string? nombre, string? desc, string? marca, double precio, int stock)
        {
            try
            {
                var producto = new Producto
                {
                    Nombre = nombre ?? string.Empty,  // Usar valor predeterminado si es null
                    Descripcion = desc ?? string.Empty,
                    Marca = marca ?? string.Empty,
                    Precio = precio,
                    Stock = stock
                };

                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar producto: " + ex.Message);
            }
        }


        // Método para editar un producto existente de manera asincrónica
        public async Task Editar(int id, string nombre, string desc, string marca, double precio, int stock)
        {
            try
            {
                var producto = await _context.Productos.FindAsync(id);
                if (producto == null)
                {
                    throw new Exception("Producto no encontrado");
                }

                // Modificar las propiedades del producto
                producto.Nombre = nombre;
                producto.Descripcion = desc;
                producto.Marca = marca;
                producto.Precio = precio;
                producto.Stock = stock;

                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar producto: " + ex.Message);
            }
        }

        // Método para eliminar un producto de manera asincrónica
        public async Task Eliminar(int id)
        {
            try
            {
                var producto = await _context.Productos.FindAsync(id);
                if (producto == null)
                {
                    throw new Exception("Producto no encontrado");
                }

                // Eliminar el producto
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar producto: " + ex.Message);
            }
        }
    }
}
