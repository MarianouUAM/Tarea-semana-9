using System;
using System.Collections.Generic;

namespace InventarioTienda
{
    internal class Program
    {
        // Almacena produ
        public class Producto
        {
            public int Codigo;
            public string Nombre;
            public int Cantidad;
            public double Precio;

            // Constructor
            public Producto(int codigo, string nombre, int cantidad, double precio)
            {
                Codigo = codigo;
                Nombre = nombre;
                Cantidad = cantidad;
                Precio = precio;
            }

            // Muestra info del producto 
            public void MostrarProducto()
            {
                Console.WriteLine($"Código: {Codigo}, Nombre: {Nombre}, Cantidad: {Cantidad}, Precio: {Precio:C2}");
            }
        }

        static void Main(string[] args)
        {
            List<Producto> inventario = new List<Producto>();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n--- Menú de Inventario ---");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Eliminar producto");
                Console.WriteLine("3. Modificar producto");
                Console.WriteLine("4. Consultar producto");
                Console.WriteLine("5. Mostrar todos los productos");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarProducto(inventario);
                        break;
                    case "2":
                        EliminarProducto(inventario);
                        break;
                    case "3":
                        ModificarProducto(inventario);
                        break;
                    case "4":
                        ConsultarProducto(inventario);
                        break;
                    case "5":
                        MostrarTodosProductos(inventario);
                        break;
                    case "6":
                        continuar = false;
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        // Agregar producto 
        public static void AgregarProducto(List<Producto> inventario)
        {
            Console.Write("Introduzca el código del producto: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Introduzca el nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.Write("Introduzca la cantidad del producto: ");
            int cantidad = int.Parse(Console.ReadLine());

            Console.Write("Introduzca el precio del producto: ");
            double precio = double.Parse(Console.ReadLine());

            Producto nuevoProducto = new Producto(codigo, nombre, cantidad, precio);
            inventario.Add(nuevoProducto);
            Console.WriteLine("Producto agregado correctamente.");
        }

        // Eliminar un produto
        public static void EliminarProducto(List<Producto> inventario)
        {
            Console.Write("Introduzca el código del producto a eliminar: ");
            int codigo = int.Parse(Console.ReadLine());

            Producto producto = inventario.Find(p => p.Codigo == codigo);

            if (producto != null)
            {
                inventario.Remove(producto);
                Console.WriteLine("Producto eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        // Modificar un producto 
        public static void ModificarProducto(List<Producto> inventario)
        {
            Console.Write("Introduzca el código del producto a modificar: ");
            int codigo = int.Parse(Console.ReadLine());

            Producto producto = inventario.Find(p => p.Codigo == codigo);

            if (producto != null)
            {
                Console.Write("Introduzca el nuevo nombre (dejar en blanco para mantener el actual): ");
                string nuevoNombre = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevoNombre))
                {
                    producto.Nombre = nuevoNombre;
                }

                Console.Write("Introduzca la nueva cantidad (dejar en blanco para mantener el actual): ");
                string nuevaCantidad = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevaCantidad))
                {
                    producto.Cantidad = int.Parse(nuevaCantidad);
                }

                Console.Write("Introduzca el nuevo precio (dejar en blanco para mantener el actual): ");
                string nuevoPrecio = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevoPrecio))
                {
                    producto.Precio = double.Parse(nuevoPrecio);
                }

                Console.WriteLine("Producto modificado correctamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        // Consultar un producto 
        public static void ConsultarProducto(List<Producto> inventario)
        {
            Console.Write("Introduzca el código del producto a consultar: ");
            int codigo = int.Parse(Console.ReadLine());

            Producto producto = inventario.Find(p => p.Codigo == codigo);

            if (producto != null)
            {
                producto.MostrarProducto();
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        // Mostrar los productos en el inventario 
        public static void MostrarTodosProductos(List<Producto> inventario)
        {
            if (inventario.Count > 0)
            {
                Console.WriteLine("\n--- Productos en inventario ---");
                foreach (var producto in inventario)
                {
                    producto.MostrarProducto();
                }
            }
            else
            {
                Console.WriteLine("No hay productos en el inventario.");
            }
        }
    }
}
