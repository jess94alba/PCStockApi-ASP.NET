using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class DetallePedido
{
    public long DetalleId { get; set; }

    public long PedidoId { get; set; }

    public long ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnit { get; set; }

    public long? TipoId { get; set; }

    public virtual Pedido Pedido { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
