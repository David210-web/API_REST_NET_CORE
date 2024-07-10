﻿using System;
using System.Collections.Generic;

namespace API_REST.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
