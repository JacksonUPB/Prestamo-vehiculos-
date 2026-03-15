using System;

namespace Local_Prestamo_Vehículos
{
    public class Prestamo
    {
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public Cliente Cliente { get; set; }
        public Vehiculo Vehiculo { get; set; }

        public Prestamo(Cliente cliente, Vehiculo vehiculo, DateTime fechaPrestamo)
        {
            Cliente = cliente;
            Vehiculo = vehiculo;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = null;
        }
    }
}