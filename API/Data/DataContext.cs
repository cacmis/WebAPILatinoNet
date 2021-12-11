using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        :base(options)
        {
            
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario>   Usuarios {get;set;}
    }
}