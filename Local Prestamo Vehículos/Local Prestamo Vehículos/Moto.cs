using System;
using System.Collections.Generic;
using System.Text;

namespace Local_Prestamo_Vehículos
{
    public class Moto : Vehiculo
    {
        public int Cilindraje { get; set; }

        public Moto(string placa, string marca, int modelo, bool disponible, int cilindraje, bool buenEstado)
            : base(placa, marca, modelo, disponible, buenEstado)
        {
            Cilindraje = cilindraje;
        }

        public override void Prestar()
        {
            Disponible = false;
            Console.WriteLine($"La moto {Placa} ha sido prestada.");
        }

        public override void Devolver()
        {
            Disponible = true;
            Console.WriteLine($"La moto {Placa} ha sido devuelta.");
        }
    }
}
