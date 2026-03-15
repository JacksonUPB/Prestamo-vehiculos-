using System;
using System.Collections.Generic;
using System.Linq;

namespace Local_Prestamo_Vehículos
{
    public class UICliente
    {
        private List<Cliente> _clientes;

        public UICliente(List<Cliente> clientes)
        {
            _clientes = clientes;
        }

        public void MostrarMenu()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n=== Menú Clientes ===");
                Console.WriteLine("1. Registrar Cliente");
                Console.WriteLine("2. Modificar Cliente");
                Console.WriteLine("3. Eliminar Cliente");
                Console.WriteLine("4. Listar Clientes");
                Console.WriteLine("5. Regresar al Menú Principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = 0;

                switch (opcion)
                {
                    case 1:
                        CrearCliente();
                        break;
                    case 2:
                        ModificarCliente();
                        break;
                    case 3:
                        EliminarCliente();
                        break;
                    case 4:
                        ListarClientes();
                        break;
                    case 5:
                        Console.WriteLine("Regresando...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 5);
        }

        private void CrearCliente()
        {
            Console.Write("ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Tiene licencia (true/false): ");
            if (!bool.TryParse(Console.ReadLine(), out bool tieneLicencia)) tieneLicencia = false;
            Console.Write("Edad: ");
            if (!int.TryParse(Console.ReadLine(), out int edad)) edad = 0;

            _clientes.Add(new Cliente(id, nombre, tieneLicencia, edad));
            Console.WriteLine("Cliente registrado exitosamente.");
        }

        private void ModificarCliente()
        {
            Console.Write("Ingrese el ID del cliente a modificar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var cliente = _clientes.FirstOrDefault(c => c.Id == id);
                if (cliente != null)
                {
                    Console.Write("Nuevo Nombre (deje vacío para no cambiar): ");
                    string nombre = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nombre)) cliente.Nombre = nombre;

                    Console.Write("Tiene licencia (true/false) (deje vacío para no cambiar): ");
                    string licencia = Console.ReadLine();
                    if (bool.TryParse(licencia, out bool tieneLicencia)) cliente.TieneLicencia = tieneLicencia;

                    Console.Write("Nueva Edad (0 para no cambiar): ");
                    if (int.TryParse(Console.ReadLine(), out int edad) && edad > 0) cliente.Edad = edad;

                    Console.WriteLine("Cliente modificado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Cliente no encontrado.");
                }
            }
        }

        private void EliminarCliente()
        {
            Console.Write("Ingrese el ID del cliente a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var cliente = _clientes.FirstOrDefault(c => c.Id == id);
                if (cliente != null)
                {
                    _clientes.Remove(cliente);
                    Console.WriteLine("Cliente eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Cliente no encontrado.");
                }
            }
        }

        private void ListarClientes()
        {
            Console.WriteLine("--- Lista de Clientes ---");
            if (_clientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados.");
                return;
            }
            foreach (var c in _clientes)
            {
                Console.WriteLine($"ID: {c.Id} | Nombre: {c.Nombre} | Licencia: {c.TieneLicencia} | Edad: {c.Edad}");
            }
        }
    }
}
