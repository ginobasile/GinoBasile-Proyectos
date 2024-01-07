using System;
using System.Collections.Generic;
using System.Text;

namespace Concesionaria
{
    class Vehiculo
    {
        public int ID { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public Boolean esUsado { get; set; }
        public double cantKm { get; set; }

        public Vehiculo()
        {

        }

        public Vehiculo(int ID, string marca, string modelo, Boolean esUsado, double cantKm)
        {
            this.ID = ID;
            this.marca = marca;
            this.modelo = modelo;
            this.esUsado = esUsado;
            this.cantKm = cantKm;
        }

    }

   


}
