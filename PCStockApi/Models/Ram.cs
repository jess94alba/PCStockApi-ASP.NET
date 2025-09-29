using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class Ram
{
    public long RamId { get; set; }

    public long ProductoId { get; set; }

    public int? CapacidadGb { get; set; }

    public string? Velocidad { get; set; }

    public string? Latencia { get; set; }

    public string? Formato { get; set; }

    public string? Voltaje { get; set; }

    public string? Disipador { get; set; }

    public string? Rgb { get; set; }

    public string? OtrasCaracteristicas { get; set; }

    public long? TipoMemoriaId { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual TipoMemorium? TipoMemoria { get; set; }
}
