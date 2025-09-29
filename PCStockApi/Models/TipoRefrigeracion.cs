using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class TipoRefrigeracion
{
    public long TipoRefrigeracionId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Refrigeracion> Refrigeracions { get; set; } = new List<Refrigeracion>();
}
