using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class TipoDisco
{
    public long TipoDiscoId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Disco> Discos { get; set; } = new List<Disco>();
}
