using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MVCConcesionaria.Models
{
    public class Auto : Vehiculo
    {

        [DisplayName("Cantidad de puertas")]
        public int CantPuertas { get; set; }

        public Auto()
        {
        }

        public Auto(int ID, string marca, string modelo, Boolean esUsado, double cantKm, int puertas) : base(ID, marca, modelo, esUsado, cantKm)
        {
            this.CantPuertas = puertas;
        }

    }
}
