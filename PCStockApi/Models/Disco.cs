using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class Disco
{
    public long DiscoId { get; set; }

    public long ProductoId { get; set; }

    public string? Capacidad { get; set; }

    public string? Velocidad { get; set; }

    public string? Formato { get; set; }

    public long? TipoDiscoId { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual TipoDisco? TipoDisco { get; set; }
}
