using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class Pedido
{
    public long PedidoId { get; set; }

    public long UsuarioId { get; set; }

    public DateTime Fecha { get; set; }

    public string Estado { get; set; } = null!;

    public decimal? Total { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual ICollection<Ensamblaje> Ensamblajes { get; set; } = new List<Ensamblaje>();

    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();

    public virtual ICollection<PedidoEnsamblaje> PedidoEnsamblajes { get; set; } = new List<PedidoEnsamblaje>();

    public virtual Usuario Usuario { get; set; } = null!;
}
