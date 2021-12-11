using API.Models;

namespace API.Data.Interfaces
{
    public interface IAuthRepository
    {
         Task<Usuario> Registrar( Usuario usuario, string password);
         Task<Usuario> Login(string Correo, string password);
         Task<bool> ExisteUsuario(string correo);
    }
}