using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrdenesDetalle.Models;

namespace OrdenesDetalle.DAL
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\luisd\OneDrive\Escritorio\Universidad\Programacion Aplicada 2\Base_de_Datos_de_Blazor\OrdenesDB\OrdenDB.db");
        }

        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Suplidores> Suplidores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            {
                SuplidorId = 1,
                Nombres = "Rica"
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 1,
                Descripcion = "Choco Rica",
                Costo = 25,
                Inventario = 10
            });
        }
    }
}
