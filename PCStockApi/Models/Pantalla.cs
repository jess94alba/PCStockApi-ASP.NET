using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class Pantalla
{
    public long MonitorId { get; set; }

    public long ProductoId { get; set; }

    public int? Pulgadas { get; set; }

    public int? Frecuencia { get; set; }

    public string? Resolucion { get; set; }

    public string? Panel { get; set; }

    public string? Respuesta { get; set; }

    public string? Conexion { get; set; }

    public string? Curvatura { get; set; }

    public string? OtrasCaracteristicas { get; set; }

    public virtual Producto Producto { get; set; } = null!;
}
