using Microsoft.EntityFrameworkCore;
using Tarea.Modelos;

namespace Tarea.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<OrdenCompra> Ordenes { get; set; }
        public DbSet<OrdenProducto> OrdenesProductos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar relaciones
            modelBuilder.Entity<OrdenProducto>()
                .HasOne(op => op.Orden)
                .WithMany(o => o.Productos)
                .HasForeignKey(op => op.OrdenId);

            modelBuilder.Entity<OrdenProducto>()
                .HasOne(op => op.Producto)
                .WithMany()
                .HasForeignKey(op => op.ProductoId);
        }
    }
}

