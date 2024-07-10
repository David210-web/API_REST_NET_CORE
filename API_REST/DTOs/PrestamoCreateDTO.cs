namespace API_REST.DTOs
{
    public class PrestamoCreateDTO
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public int LibroId { get; set; }

        public DateOnly FechaPrestamo { get; set; }

        public DateOnly FechaDevolucion { get; set; }
        public string Estado { get; set; } = null!;

    }
}
