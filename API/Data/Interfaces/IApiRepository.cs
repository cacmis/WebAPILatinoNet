using API.Models;

namespace API.Data.Interfaces
{
    public interface IApiRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<IEnumerable<Producto>> GetProductosAsync();
        Task<Producto> GetProductoByIdAsync(int id);
        Task<Producto> GetProductoByNombreAsync(string nombre);
    }
}