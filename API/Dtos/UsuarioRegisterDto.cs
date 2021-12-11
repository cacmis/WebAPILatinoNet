namespace API.Dtos
{
    public class UsuarioRegisterDto
    {
        public string Correo { get; set; }
        public string Password { get; set; }     
        public string Nombre { get; set; }
        public DateTime FechaDeAlta { get; set; }

        public UsuarioRegisterDto()
        {
            FechaDeAlta = DateTime.Now;
        }
    }
}