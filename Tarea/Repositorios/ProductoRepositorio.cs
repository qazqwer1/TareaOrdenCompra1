using Microsoft.EntityFrameworkCore;
using System;
using Tarea.Data;
using Tarea.Modelos;

namespace Tarea.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly AppDbContext _context;

        public ProductoRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto?> GetByIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<Producto> AddAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }
    }
}
