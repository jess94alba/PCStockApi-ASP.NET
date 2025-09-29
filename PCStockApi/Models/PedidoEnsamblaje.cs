using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class PedidoEnsamblaje
{
    public long Id { get; set; }

    public long PedidoId { get; set; }

    public long EnsamblajeId { get; set; }

    public virtual Ensamblaje Ensamblaje { get; set; } = null!;

    public virtual Pedido Pedido { get; set; } = null!;
}
