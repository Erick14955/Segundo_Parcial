using Microsoft.EntityFrameworkCore;
using Segundo_Parcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segundo_Parcial.DAL
{
    class Contexto: DbContext
    {
        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<Tarea> Tarea { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data/datosProyecto.Db");
        }
    }
}
