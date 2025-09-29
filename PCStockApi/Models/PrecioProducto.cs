using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class PrecioProducto
{
    public long PrecioId { get; set; }

    public long ProductoId { get; set; }

    public decimal PrecioBase { get; set; }

    public int? PorcentajeGanancia { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public long? TipoId { get; set; }

    public virtual Producto Producto { get; set; } = null!;
}
