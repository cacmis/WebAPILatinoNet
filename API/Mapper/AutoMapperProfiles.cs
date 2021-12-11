using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Mapper
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            // POST o CREATE
            CreateMap<ProductoCreateDto,Producto>();
            // PUT o UPDATE
            CreateMap<ProductoUpdateDto,Producto>();
            // GET o LIST
            CreateMap<Producto,ProductoToListDto>();

             // Usuarios
            CreateMap<UsuarioRegisterDto, Usuario>();
            CreateMap<UsuarioLoginDto, Usuario>();
            CreateMap<Usuario,UsuarioListDto>(); 
        }
    }
}