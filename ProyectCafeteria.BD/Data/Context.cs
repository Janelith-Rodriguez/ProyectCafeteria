using Microsoft.EntityFrameworkCore;
using ProyectCafeteria.BD.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCafeteria.BD.Data
{
    public class Context : DbContext
    {
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}
