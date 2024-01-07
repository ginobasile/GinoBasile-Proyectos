using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MVCConcesionaria.Models
{
    public class VentaAuto
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdVentAuto { get; set; }

		public int? IdCliente { get; set; }
		[NotMapped]
		public Persona cliente { get; set; }

		public int? Id { get; set; }    // ? puede ser nullable

		[NotMapped]
		public Auto auto { get; set; }
	}
}
