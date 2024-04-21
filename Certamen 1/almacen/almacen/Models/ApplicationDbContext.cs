using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;

namespace almacen.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public
ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
 : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
