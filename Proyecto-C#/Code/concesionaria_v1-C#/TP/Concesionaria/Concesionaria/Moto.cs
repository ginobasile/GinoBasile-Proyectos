using System;
using System.Collections.Generic;
using System.Text;

namespace Concesionaria
{
    class Moto : Vehiculo
    {
        
        public TipoMoto tipo { get; set; }
        public Moto()
        {

        }

        public Moto(int ID, string marca, string modelo, Boolean esUsado, double cantKm, TipoMoto tipo) : base(ID, marca, modelo, esUsado, cantKm)
        {
            this.tipo = tipo;
        }
        
    }
}
