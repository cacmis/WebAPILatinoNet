namespace API.Dtos
{
    public class ProductoCreateDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Decimal Precio { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public ProductoCreateDto()
        {
            FechaDeAlta = DateTime.Now;
        }
    }
}