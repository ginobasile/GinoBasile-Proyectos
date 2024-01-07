using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MVCConcesionaria.Models
{
    public class Moto : Vehiculo
    {
        [EnumDataType(typeof(TipoMoto))]
        public TipoMoto Tipo { get; set; }
        public Moto()
        {

        }

        public Moto(int ID, string Marca, string Modelo, Boolean EsUsado, double CantKm, TipoMoto Tipo) : base(ID, Marca, Modelo, EsUsado, CantKm)
        {
            this.Tipo = Tipo;
        }

    }
}
