using System;
using System.Collections.Generic;
using System.Linq;

namespace Local_Prestamo_Vehículos
{
    public class UIMecanico
    {
        private List<Mecanico> _mecanicos;

        public UIMecanico(List<Mecanico> mecanicos)
        {
            _mecanicos = mecanicos;
        }

        public void MostrarMenu()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n=== Menú Mecánicos ===");
                Console.WriteLine("1. Registrar Mecánico");
                Console.WriteLine("2. Modificar Nombre de Mecánico");
                Console.WriteLine("3. Eliminar Mecánico");
                Console.WriteLine("4. Listar Mecánicos");
                Console.WriteLine("5. Regresar al Menú Principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = 0;

                switch (opcion)
                {
                    case 1:
                        CrearMecanico();
                        break;
                    case 2:
                        ModificarMecanico();
                        break;
                    case 3:
                        EliminarMecanico();
                        break;
                    case 4:
                        ListarMecanicos();
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

        private void CrearMecanico()
        {
            Console.Write("Nombre del mecánico: ");
            string nombre = Console.ReadLine();
            
            _mecanicos.Add(new Mecanico(nombre));
            Console.WriteLine("Mecánico registrado exitosamente.");
        }

        private void ModificarMecanico()
        {
            Console.Write("Ingrese el nombre actual del mecánico a modificar (sensible a mayúsculas/minúsculas): ");
            string nombreAnterior = Console.ReadLine();
            var mecanico = _mecanicos.FirstOrDefault(m => m.Nombre == nombreAnterior);
            if (mecanico != null)
            {
                Console.Write("Nuevo nombre del mecánico: ");
                string nuevoNombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuevoNombre))
                {
                    mecanico.Nombre = nuevoNombre;
                    Console.WriteLine("Mecánico modificado exitosamente.");
                }
            }
            else
            {
                Console.WriteLine("Mecánico no encontrado.");
            }
        }

        private void EliminarMecanico()
        {
            Console.Write("Ingrese el nombre del mecánico a eliminar: ");
            string nombre = Console.ReadLine();
            var mecanico = _mecanicos.FirstOrDefault(m => m.Nombre == nombre);
            if (mecanico != null)
            {
                _mecanicos.Remove(mecanico);
                Console.WriteLine("Mecánico eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Mecánico no encontrado.");
            }
        }

        private void ListarMecanicos()
        {
            Console.WriteLine("--- Lista de Mecánicos ---");
            if (_mecanicos.Count == 0)
            {
                Console.WriteLine("No hay mecánicos registrados.");
                return;
            }
            foreach (var m in _mecanicos)
            {
                Console.WriteLine($"- Nombre: {m.Nombre}");
            }
        }
    }
}