using System;

namespace Local_Prestamo_Vehículos
{
    public abstract class Vehiculo : IPrestable
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public int Modelo { get; set; }
        public bool Disponible { get; set; }
        public bool BuenEstado { get; set; }

        public Vehiculo(string placa, string marca, int modelo, bool disponible, bool buenEstado)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Disponible = disponible;
            BuenEstado = buenEstado;
        }

        public abstract void Prestar();
        public abstract void Devolver();
    }
}
