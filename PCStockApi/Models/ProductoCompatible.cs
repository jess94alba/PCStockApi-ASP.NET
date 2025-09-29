using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class ProductoCompatible
{
    public long ProductoCompatibleId { get; set; }

    public long ProductoId { get; set; }

    public long ProductoCompatibleConId { get; set; }

    public string? TipoRelacion { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Producto ProductoCompatibleCon { get; set; } = null!;
}
