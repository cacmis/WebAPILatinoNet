using API.Data.Interfaces;
using API.Dtos;
using API.Models;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AuthController(IAuthRepository repo,ITokenService tokenService,IMapper mapper)
        {
            _repo= repo;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UsuarioRegisterDto usuarioDto)
        {
            usuarioDto.Correo = usuarioDto.Correo.ToLower();
            if(await _repo.ExisteUsuario(usuarioDto.Correo))
                return BadRequest("Usuario con ese correo ya esta registrado");
            
            var usuarioNuevo = _mapper.Map<Usuario>(usuarioDto);
            var usuarioCreado = await _repo.Registrar(usuarioNuevo,usuarioDto.Password);
            var usuarioCreadoDto = _mapper.Map<UsuarioListDto>(usuarioCreado);
            return Ok(usuarioCreadoDto);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UsuarioLoginDto usuarioLoginDto)
        {
            var usuarioFromRepo = await _repo.Login(usuarioLoginDto.correo, usuarioLoginDto.Password);

            if(usuarioFromRepo == null)
                return Unauthorized();
            var usuario = _mapper.Map<UsuarioListDto>(usuarioFromRepo);

            var token = _tokenService.CreateToken(usuarioFromRepo);

            return Ok(new {
                token= token,
                usuario = usuario
            });

        }

        
    }
}