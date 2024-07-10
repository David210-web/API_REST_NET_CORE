using System;
using System.Collections.Generic;

namespace API_REST.Models;

public partial class Libro
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public int AutorId { get; set; }

    public int CategoriaId { get; set; }

    public string? Sinopsis { get; set; }

    public DateOnly FechaPublicacion { get; set; }

    public bool Disponible { get; set; }

    public virtual Autore Autor { get; set; } = null;

    public virtual Categoria Categoria { get; set; } = null;


    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
