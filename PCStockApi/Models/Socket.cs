using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class Socket
{
    public long SocketId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Board> Boards { get; set; } = new List<Board>();

    public virtual ICollection<Procesador> Procesadors { get; set; } = new List<Procesador>();

    public virtual ICollection<Refrigeracion> Refrigeracions { get; set; } = new List<Refrigeracion>();
}
