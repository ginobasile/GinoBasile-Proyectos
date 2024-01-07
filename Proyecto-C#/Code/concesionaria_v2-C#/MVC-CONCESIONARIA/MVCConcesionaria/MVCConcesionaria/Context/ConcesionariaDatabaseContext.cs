using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCConcesionaria.Models;
namespace MVCConcesionaria.Context
{
    public class ConcesionariaDatabaseContext : DbContext

    {
        public
        ConcesionariaDatabaseContext(DbContextOptions<ConcesionariaDatabaseContext> options)
        : base(options)
        {
        }
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Camioneta> Camionetas { get; set; }
        public DbSet<MVCConcesionaria.Models.Persona> Persona { get; set; }
        public DbSet<MVCConcesionaria.Models.VentaMoto> VentaMoto { get; set; }
        public DbSet<MVCConcesionaria.Models.VentaAuto> VentaAuto { get; set; }
        public DbSet<MVCConcesionaria.Models.VentaCamioneta> VentaCamioneta { get; set; }


    }
}