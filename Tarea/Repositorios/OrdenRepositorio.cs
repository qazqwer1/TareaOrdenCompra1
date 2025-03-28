using Microsoft.EntityFrameworkCore;
using Tarea.Data;
using Tarea.Modelos;

namespace Tarea.Repositorios
{
    public class OrdenRepositorio : IOrdenRepositorio
    {
        private readonly AppDbContext _context;

        public OrdenRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrdenCompra>> GetAllAsync(int page, int pageSize)
        {
            return await _context.Ordenes
             .Include(o => o.Productos)
                 .ThenInclude(op => op.Producto)
             .Skip((page - 1) * pageSize)
             .Take(pageSize)
             .ToListAsync();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Ordenes.CountAsync();
        }

        public async Task<OrdenCompra?> GetByIdAsync(int id)
        {
            return await _context.Ordenes
                .Include(o => o.Productos)
                    .ThenInclude(op => op.Producto)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<OrdenCompra> AddAsync(OrdenCompra orden)
        {
            _context.Ordenes.Add(orden);
            await _context.SaveChangesAsync();
            return orden;
        }

        public async Task<OrdenCompra?> UpdateAsync(int id, OrdenCompra orden)
        {
            var existente = await _context.Ordenes
                .Include(o => o.Productos)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (existente == null) return null;

            existente.Cliente = orden.Cliente;
            existente.Productos = orden.Productos;
            existente.Total = orden.Total;

            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var orden = await _context.Ordenes.FindAsync(id);
            if (orden == null) return false;

            _context.Ordenes.Remove(orden);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
