using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class Envio
{
    public long EnvioId { get; set; }

    public long PedidoId { get; set; }

    public long DireccionId { get; set; }

    public DateTime? FechaEnvio { get; set; }

    public string EstadoEnvio { get; set; } = null!;

    public string? Tracking { get; set; }

    public virtual Direccion Direccion { get; set; } = null!;

    public virtual Pedido Pedido { get; set; } = null!;
}
