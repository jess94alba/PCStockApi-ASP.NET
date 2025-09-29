using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class Potencium
{
    public long PotenciaId { get; set; }

    public int Watts { get; set; }

    public virtual ICollection<Fuente> Fuentes { get; set; } = new List<Fuente>();

    public virtual ICollection<TarjetaVideo> TarjetaVideos { get; set; } = new List<TarjetaVideo>();
}
