using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class Ensamblaje
{
    public long EnsamblajeId { get; set; }

    public long? PedidoId { get; set; }

    public DateTime? FechaEnsamblaje { get; set; }

    public string Estado { get; set; } = null!;

    public string? Observacion { get; set; }

    public virtual Pedido? Pedido { get; set; }

    public virtual ICollection<PedidoEnsamblaje> PedidoEnsamblajes { get; set; } = new List<PedidoEnsamblaje>();
}
