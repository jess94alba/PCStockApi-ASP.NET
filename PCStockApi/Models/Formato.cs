using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class Formato
{
    public long FormatoId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Board> Boards { get; set; } = new List<Board>();
}
