using System;
using System.Collections.Generic;
using System.Text;

namespace Concesionaria
{
    class Camioneta : Vehiculo
    {
        public Boolean es4x4 { get; set; }
        public Boolean esDobleCabina { get; set; }

        public Camioneta()
        {

        }

        public Camioneta(int ID, string marca, string modelo, Boolean esUsado, double cantKm, Boolean es4x4, Boolean dobleCab) : base(ID, marca, modelo, esUsado, cantKm)
        {
            this.es4x4 = es4x4;
            this.esDobleCabina = dobleCab;
        }
    }
}
