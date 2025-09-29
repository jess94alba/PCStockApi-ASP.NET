using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class Board
{
    public long BoardId { get; set; }

    public long ProductoId { get; set; }

    public string? Chipset { get; set; }

    public string? Almacenamiento { get; set; }

    public string? Expansion { get; set; }

    public string? PuertosExternos { get; set; }

    public string? Video { get; set; }

    public string? OtrasCaracteristicas { get; set; }

    public long? SocketId { get; set; }

    public long? TipoMemoriaId { get; set; }

    public long? FormatoId { get; set; }

    public virtual Formato? Formato { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Socket? Socket { get; set; }

    public virtual TipoMemorium? TipoMemoria { get; set; }
}
