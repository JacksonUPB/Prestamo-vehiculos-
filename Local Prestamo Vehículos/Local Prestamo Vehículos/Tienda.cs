using System;
using System.Collections.Generic;
using System.Text;

namespace Local_Prestamo_Vehículos
{
    public class Tienda
    {
        public bool Abierta { get; set; }
        public List<Vehiculo> ListaVehiculos { get; set; } = new List<Vehiculo>();
        public List<Mecanico> ListaMecanicos { get; set; } = new List<Mecanico>();
        public List<Prestamo> ListaPrestamos { get; set; } = new List<Prestamo>();

        public void PrestarVehiculo(Vehiculo vehiculo, Cliente cliente, DateTime fechaPrestamo)
        {
            // Validar la edad y licencia del cliente
            if (cliente.Edad < 17 || !cliente.TieneLicencia)
            {
                Console.WriteLine($"[Rechazado] El cliente {cliente.Nombre} no cumple los requisitos (menor de 17 o falta de licencia).");
                return;
            }

            // Validar si el vehículo está en mal estado y necesita reparación
            if (!vehiculo.BuenEstado)
            {
                Console.WriteLine($"[Alerta] El vehículo {vehiculo.Placa} está en mal estado.");
                if (ListaMecanicos.Any())
                {
                    Mecanico mecanicoAsignado = ListaMecanicos.First();
                    mecanicoAsignado.RepararVehiculo(vehiculo);
                }
                else
                {
                    Console.WriteLine("No hay mecánicos disponibles para repararlo. No puede ser prestado.");
                    return;
                }
            }

            if (vehiculo.Disponible)
            {
                cliente.SolicitarPrestamo();
                vehiculo.Prestar();
                Prestamo nuevoPrestamo = new Prestamo(cliente, vehiculo, fechaPrestamo);
                ListaPrestamos.Add(nuevoPrestamo);
                Console.WriteLine($"[Completado] El préstamo del vehículo {vehiculo.Placa} al cliente {cliente.Nombre} fue exitoso.");
            }
            else
            {
                Console.WriteLine("El vehículo actualmente no está disponible.");
            }
        }

        public void RecibirVehiculo(Cliente cliente, Vehiculo vehiculo, DateTime fechaDevolucion)
        {
            var prestamo = ListaPrestamos.FirstOrDefault(p => p.Vehiculo == vehiculo && p.Cliente == cliente && p.FechaDevolucion == null);
            if (prestamo != null)
            {
                cliente.DevolverVehiculo();
                vehiculo.Devolver();
                prestamo.FechaDevolucion = fechaDevolucion;
                Console.WriteLine($"[Completado] Vehículo {vehiculo.Placa} recibido exitosamente de {cliente.Nombre}.");
            }
            else
            {
                Console.WriteLine("No se encontró un préstamo activo con estos datos.");
            }
        }
    }
}
