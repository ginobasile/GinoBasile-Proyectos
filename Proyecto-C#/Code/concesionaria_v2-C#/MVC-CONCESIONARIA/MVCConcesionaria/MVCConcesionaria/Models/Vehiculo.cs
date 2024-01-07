using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MVCConcesionaria.Models
{
    public class Vehiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Se debe cargar la marca")]
        public string Marca { get; set; }


        [Required(ErrorMessage = "Se debe cargar el modelo")]
        public string Modelo { get; set; }

        [DisplayName("Es usado")]
        public Boolean EsUsado { get; set; }

        [DisplayName("Cantidad de kilometros")]
        public double CantKm { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Se debe cargar una imagen")]
        [Display(Name = "Imagen del vehiculo:")]
        public IFormFile PhotoAvatar { get; set; }

        public string ImageName { get; set; }

        public byte[] PhotoFile { get; set; }

        public string ImageMimeType { get; set; }

        [Range(500000, 20000000000, ErrorMessage = "Se debe cargar un año entre {1} y {2}")]
        [Required(ErrorMessage = "Se debe cargar su precio")]
        [Display(Name = "Precio:")]
        public int Precio { get; set; }

        [Range(2010, 2022,ErrorMessage ="Se debe cargar un año entre {1} y {2}")]
        [Required(ErrorMessage = "Se debe cargar el año")]
        [Display(Name = "Año:")]
        public int Anio {get;set; }

        [NotMapped]
        public String datosVehiculo
        {
            get
            {
                return "Marca: " + Marca + " - modelo: " + Modelo + " - Precio: $" + Precio + " - Año: " + Anio;
            }
        }
        public Vehiculo()
        {

        }

        public Vehiculo(int ID, string marca, string modelo, Boolean esUsado, double cantKm)
        {
            this.ID = ID;
            this.Marca = marca;
            this.Modelo = modelo;
            this.EsUsado = esUsado;
            this.CantKm = cantKm;
        }

    }




}
