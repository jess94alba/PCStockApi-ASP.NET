using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class Chasi
{
    public long ChasisId { get; set; }

    public long ProductoId { get; set; }

    public string? Formato { get; set; }

    public string? PuertosExternos { get; set; }

    public int? NumeroVentiladores { get; set; }

    public string? OtrasCaracteristicas { get; set; }

    public virtual Producto Producto { get; set; } = null!;
}
