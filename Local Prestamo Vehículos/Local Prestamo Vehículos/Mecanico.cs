using System;
using System.Collections.Generic;
using System.Text;

namespace Local_Prestamo_Vehículos
{
    public class Mecanico
    {
        public string Nombre { get; set; }

        public Mecanico(string nombre)
        {
            Nombre = nombre;
        }

        public void RepararVehiculo(Vehiculo vehiculo)
        {
            Console.WriteLine($"El mecánico {Nombre} está reparando el vehículo con placa {vehiculo.Placa}.");
            vehiculo.BuenEstado = true; // El vehículo queda reparado
        }
    }
}
