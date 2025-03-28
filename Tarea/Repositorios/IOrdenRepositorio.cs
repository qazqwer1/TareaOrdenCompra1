using Tarea.Modelos;

namespace Tarea.Repositorios
{
    public interface IOrdenRepositorio
    {
        Task<IEnumerable<OrdenCompra>> GetAllAsync(int page, int pageSize);
        Task<OrdenCompra?> GetByIdAsync(int id);
        Task<OrdenCompra> AddAsync(OrdenCompra orden);
        Task<OrdenCompra?> UpdateAsync(int id, OrdenCompra orden);
        Task<bool> DeleteAsync(int id);
        Task<int> GetTotalCountAsync();
    }
}
