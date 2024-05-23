using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace trabajo2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext> options) :
       base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
    }
}
