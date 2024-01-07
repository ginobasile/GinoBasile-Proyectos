using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MVCConcesionaria.Models
{
    public class Persona
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "Se debe cargar el dni")]
        [DisplayName("DNI")]
        public int PersonaDNI { get; set; }

        [Required(ErrorMessage = "Se debe cargar el nombre")]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Se debe cargar el apellido")]
        [DisplayName("Apellido")]
        public string Apellido { get; set; }

        [NotMapped]
        public String datosPersona {
            get {
                return Nombre + " - " + Apellido + " - " + PersonaDNI;
                } 
        }
        public Persona()
        {

        }

        public Persona(string n, string a, int d)
        {
            Nombre = n;
            Apellido = a;
            PersonaDNI = d;
        }
    }
}
