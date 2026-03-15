using System;
using System.Collections.Generic;

namespace Local_Prestamo_Vehículos
{
    class Program
    {
        static void Main(string[] args)
        {
            Tienda miTienda = new Tienda { Abierta = true };

            // Iniciar menú principal en UITienda
            UITienda uiTienda = new UITienda(miTienda);
            uiTienda.MostrarMenu();
        }
    }
}
