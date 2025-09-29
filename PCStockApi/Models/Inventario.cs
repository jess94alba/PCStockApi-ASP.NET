using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class Inventario
{
    public long InventarioId { get; set; }

    public long ProductoId { get; set; }

    public int Cantidad { get; set; }

    public DateTime FechaMovimiento { get; set; }

    public string TipoMovimiento { get; set; } = null!;

    public string? Observacion { get; set; }

    public virtual Producto Producto { get; set; } = null!;
}
