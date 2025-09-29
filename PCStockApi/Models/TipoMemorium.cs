using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class TipoMemorium
{
    public long TipoMemoriaId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Board> Boards { get; set; } = new List<Board>();

    public virtual ICollection<Ram> Rams { get; set; } = new List<Ram>();
}
