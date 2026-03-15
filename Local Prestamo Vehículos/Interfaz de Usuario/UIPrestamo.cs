using System;
using System.Collections.Generic;
using System.Linq;

namespace Local_Prestamo_Vehículos
{
    public class UIPrestamo
    {
        private Tienda _tienda;
        private List<Cliente> _clientes;
        private List<Vehiculo> _vehiculos;

        public UIPrestamo(Tienda tienda, List<Cliente> clientes, List<Vehiculo> vehiculos)
        {
            _tienda = tienda;
            _clientes = clientes;
            _vehiculos = vehiculos;
        }

        public void MostrarMenu()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n=== Menú Préstamos ===");
                Console.WriteLine("1. Generar Nuevo Préstamo de Vehículo");
                Console.WriteLine("2. Registrar Devolución de Vehículo");
                Console.WriteLine("3. Listar Préstamos Activos");
                Console.WriteLine("4. Listar Historial Completo de Préstamos");
                Console.WriteLine("5. Regresar al Menú Principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = 0;

                switch (opcion)
                {
                    case 1:
                        GenerarPrestamo();
                        break;
                    case 2:
                        RecibirDevolucion();
                        break;
                    case 3:
                        ListarPrestamos(true);
                        break;
                    case 4:
                        ListarPrestamos(false);
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

        private void GenerarPrestamo()
        {
            Console.Write("Ingrese el ID del Cliente: ");
            if (!int.TryParse(Console.ReadLine(), out int idCliente)) return;
            var cliente = _clientes.FirstOrDefault(c => c.Id == idCliente);
            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            Console.Write("Ingrese la Placa del Vehículo: ");
            string placa = Console.ReadLine();
            var vehiculo = _vehiculos.FirstOrDefault(v => v.Placa == placa);
            if (vehiculo == null)
            {
                Console.WriteLine("Vehículo no encontrado.");
                return;
            }

            // Uso la lógica de negocio ya en la Tienda
            _tienda.PrestarVehiculo(vehiculo, cliente, DateTime.Now);
        }

        private void RecibirDevolucion()
        {
            Console.Write("Ingrese el ID del Cliente que devuelve: ");
            if (!int.TryParse(Console.ReadLine(), out int idCliente)) return;
            var cliente = _clientes.FirstOrDefault(c => c.Id == idCliente);
            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            Console.Write("Ingrese la Placa del Vehículo a devolver: ");
            string placa = Console.ReadLine();
            var vehiculo = _vehiculos.FirstOrDefault(v => v.Placa == placa);
            if (vehiculo == null)
            {
                Console.WriteLine("Vehículo no encontrado.");
                return;
            }

            // Uso la lógica de negocio ya en la Tienda
            _tienda.RecibirVehiculo(cliente, vehiculo, DateTime.Now);
        }

        private void ListarPrestamos(bool soloActivos)
        {
            var prestamos = _tienda.ListaPrestamos;
            if (soloActivos)
                prestamos = prestamos.Where(p => p.FechaDevolucion == null).ToList();

            Console.WriteLine(soloActivos ? "--- Préstamos Activos ---" : "--- Historial de Préstamos ---");

            if (prestamos.Count == 0)
            {
                Console.WriteLine("No se encontraron registros.");
                return;
            }

            foreach (var p in prestamos)
            {
                string devuelto = p.FechaDevolucion.HasValue ? p.FechaDevolucion.Value.ToString() : "Aún en préstamo";
                Console.WriteLine($"Cliente ID: {p.Cliente.Id} | Vehículo: {p.Vehiculo.Placa} | Fecha de Préstamo: {p.FechaPrestamo} | Regreso: {devuelto}");
            }
        }
    }
}