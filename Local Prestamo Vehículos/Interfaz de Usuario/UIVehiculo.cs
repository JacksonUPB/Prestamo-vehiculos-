using System;
using System.Collections.Generic;
using System.Linq;

namespace Local_Prestamo_Vehículos
{
    public class UIVehiculo
    {
        private List<Vehiculo> _vehiculos;

        public UIVehiculo(List<Vehiculo> vehiculos)
        {
            _vehiculos = vehiculos;
        }

        public void MostrarMenu()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n=== Menú Vehículos ===");
                Console.WriteLine("1. Registrar Vehículo (Carro)");
                Console.WriteLine("2. Registrar Vehículo (Moto)");
                Console.WriteLine("3. Modificar Estado/Disponibilidad de Vehículo");
                Console.WriteLine("4. Eliminar Vehículo");
                Console.WriteLine("5. Listar Vehículos");
                Console.WriteLine("6. Regresar al Menú Principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = 0;

                switch (opcion)
                {
                    case 1:
                        CrearCarro();
                        break;
                    case 2:
                        CrearMoto();
                        break;
                    case 3:
                        ModificarVehiculo();
                        break;
                    case 4:
                        EliminarVehiculo();
                        break;
                    case 5:
                        ListarVehiculos();
                        break;
                    case 6:
                        Console.WriteLine("Regresando...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 6);
        }

        private void CrearCarro()
        {
            Console.Write("Placa: ");
            string placa = Console.ReadLine();
            Console.Write("Marca: ");
            string marca = Console.ReadLine();
            Console.Write("Modelo (Año): ");
            int modelo; int.TryParse(Console.ReadLine(), out modelo);
            Console.Write("Disponible (true/false): ");
            bool disponible; bool.TryParse(Console.ReadLine(), out disponible);
            Console.Write("Buen estado (true/false): ");
            bool buenEstado; bool.TryParse(Console.ReadLine(), out buenEstado);
            Console.Write("Asientos: ");
            int asientos; int.TryParse(Console.ReadLine(), out asientos);

            _vehiculos.Add(new Carro(placa, marca, modelo, disponible, asientos, buenEstado));
            Console.WriteLine("Carro registrado exitosamente.");
        }

        private void CrearMoto()
        {
            Console.Write("Placa: ");
            string placa = Console.ReadLine();
            Console.Write("Marca: ");
            string marca = Console.ReadLine();
            Console.Write("Modelo (Año): ");
            int modelo; int.TryParse(Console.ReadLine(), out modelo);
            Console.Write("Disponible (true/false): ");
            bool disponible; bool.TryParse(Console.ReadLine(), out disponible);
            Console.Write("Buen estado (true/false): ");
            bool buenEstado; bool.TryParse(Console.ReadLine(), out buenEstado);
            Console.Write("Cilindraje: ");
            int cilindraje; int.TryParse(Console.ReadLine(), out cilindraje);

            _vehiculos.Add(new Moto(placa, marca, modelo, disponible, cilindraje, buenEstado));
            Console.WriteLine("Moto registrada exitosamente.");
        }

        private void ModificarVehiculo()
        {
            Console.Write("Ingrese la placa del vehículo a modificar: ");
            string placa = Console.ReadLine();
            var vehiculo = _vehiculos.FirstOrDefault(v => v.Placa == placa);
            if (vehiculo != null)
            {
                Console.Write("¿Está disponible? (true/false): ");
                if (bool.TryParse(Console.ReadLine(), out bool disponible)) vehiculo.Disponible = disponible;

                Console.Write("¿Está en buen estado? (true/false): ");
                if (bool.TryParse(Console.ReadLine(), out bool buenEstado)) vehiculo.BuenEstado = buenEstado;

                Console.WriteLine("Estado del vehículo actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("Vehículo no encontrado.");
            }
        }

        private void EliminarVehiculo()
        {
            Console.Write("Ingrese la placa del vehículo a eliminar: ");
            string placa = Console.ReadLine();
            var vehiculo = _vehiculos.FirstOrDefault(v => v.Placa == placa);
            if (vehiculo != null)
            {
                _vehiculos.Remove(vehiculo);
                Console.WriteLine("Vehículo eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Vehículo no encontrado.");
            }
        }

        private void ListarVehiculos()
        {
            Console.WriteLine("--- Lista de Vehículos ---");
            if (_vehiculos.Count == 0)
            {
                Console.WriteLine("No hay vehículos registrados.");
                return;
            }
            foreach (var v in _vehiculos)
            {
                Console.WriteLine($"Placa: {v.Placa} | Marca: {v.Marca} | Modelo: {v.Modelo} | Disponible: {v.Disponible} | Buen Estado: {v.BuenEstado}");
            }
        }
    }
}