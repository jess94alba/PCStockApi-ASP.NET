using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class Fuente
{
    public long FuenteId { get; set; }

    public long ProductoId { get; set; }

    public string? Certificacion { get; set; }

    public bool? Modular { get; set; }

    public string? Ventilador { get; set; }

    public string? Protecciones { get; set; }

    public long? PotenciaId { get; set; }

    public virtual Potencium? Potencia { get; set; }

    public virtual Producto Producto { get; set; } = null!;
}
