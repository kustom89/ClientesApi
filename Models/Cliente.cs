using System;
using System.Collections.Generic;

namespace ClienteApi.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? Edad { get; set; }

    public string? Telefono { get; set; }

    public string? Nacionalidad { get; set; }
}
