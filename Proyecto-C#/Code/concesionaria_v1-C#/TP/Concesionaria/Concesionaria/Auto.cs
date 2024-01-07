using System;
using System.Collections.Generic;
using System.Text;

namespace Concesionaria
{
    class Auto : Vehiculo
    {
        public int cantPuertas { get; set; }

        public Auto()
        {
        }

        public Auto(int ID, string marca, string modelo, Boolean esUsado, double cantKm, int puertas) : base (ID, marca, modelo, esUsado, cantKm)
        {
            this.cantPuertas = puertas;
        }

    }
}
