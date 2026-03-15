using System;
using System.Collections.Generic;
using System.Text;

namespace Local_Prestamo_Vehículos
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool TieneLicencia { get; set; }
        public int Edad { get; set; }

        public Cliente(int id, string nombre, bool tieneLicencia, int edad)
        {
            Id = id;
            Nombre = nombre;
            TieneLicencia = tieneLicencia;
            Edad = edad;
        }

        public void SolicitarPrestamo()
        {
            Console.WriteLine($"El cliente {Nombre} solicita un préstamo.");
        }

        public void DevolverVehiculo()
        {
            Console.WriteLine($"El cliente {Nombre} devuelve el vehículo.");
        }
    }
}
