using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class TarjetaVideo
{
    public long TarjetaId { get; set; }

    public long ProductoId { get; set; }

    public string? Memoria { get; set; }

    public string? Chipset { get; set; }

    public string? OtrasCaracteristicas { get; set; }

    public long? PotenciaRequeridaId { get; set; }

    public virtual Potencium? PotenciaRequerida { get; set; }

    public virtual Producto Producto { get; set; } = null!;
}
