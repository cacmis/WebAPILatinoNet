using API.Data.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApiRepository: IApiRepository
    {
         private readonly DataContext _context;
        public ApiRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            var producto= await _context.Productos.FirstOrDefaultAsync(u => u.Id == id);
            return producto;
        }

        public async Task<Producto> GetProductoByNombreAsync(string nombre)
        {
            var producto= await _context.Productos.FirstOrDefaultAsync(u => u.Nombre.Trim() == nombre.Trim());
            return producto;
        }

        public async Task<IEnumerable<Producto>> GetProductosAsync()
        {
            var productos = await _context.Productos.ToListAsync();
            decimal total=0;
            foreach(var prod in productos)
                    total += prod.Precio;
                    
            return productos;
        }


        public async  Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0 ;
        }
    }
}