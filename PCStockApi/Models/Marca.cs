using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class Marca
{
    public long MarcaId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
