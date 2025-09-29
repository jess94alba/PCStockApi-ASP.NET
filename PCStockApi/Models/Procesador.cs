using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class Procesador
{
    public long ProcesadorId { get; set; }

    public long ProductoId { get; set; }

    public string? Velocidad { get; set; }

    public int? Nucleos { get; set; }

    public int? Hilos { get; set; }

    public string? Cache { get; set; }

    public string? GraficaIntegrada { get; set; }

    public string? Tecnologia { get; set; }

    public string? Consumo { get; set; }

    public string? Arquitectura { get; set; }

    public string? Bus { get; set; }

    public string? OtrasCaracteristicas { get; set; }

    public long? SocketId { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Socket? Socket { get; set; }
}
