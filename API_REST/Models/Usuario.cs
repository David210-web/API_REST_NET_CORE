﻿using System;
using System.Collections.Generic;

namespace API_REST.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string Rol { get; set; } = null!;


    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
