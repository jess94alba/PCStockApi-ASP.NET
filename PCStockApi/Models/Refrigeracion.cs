using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class Refrigeracion
{
    public long RefrigeracionId { get; set; }

    public long ProductoId { get; set; }

    public string? TamanoRadiador { get; set; }

    public string? Ventiladores { get; set; }

    public string? Iluminacion { get; set; }

    public string? CompatibilidadExtra { get; set; }

    public string? OtrasCaracteristicas { get; set; }

    public long? TipoRefrigeracionId { get; set; }

    public long? SocketCompatibleId { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Socket? SocketCompatible { get; set; }

    public virtual TipoRefrigeracion? TipoRefrigeracion { get; set; }
}
