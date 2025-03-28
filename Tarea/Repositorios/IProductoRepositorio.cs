using Tarea.Modelos;

namespace Tarea.Repositorios
{
    public interface IProductoRepositorio
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto?> GetByIdAsync(int id);
        Task<Producto> AddAsync(Producto producto);
    }
}
