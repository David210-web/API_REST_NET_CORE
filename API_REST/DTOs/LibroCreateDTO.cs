namespace API_REST.DTOs
{
    public class LibroCreateDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public int AutorId { get; set; }
        public int CategoriaId { get; set; }
        public string? Sinopsis { get; set; }
        public DateOnly FechaPublicacion { get; set; }
        public bool Disponible { get; set; }
    }
}
