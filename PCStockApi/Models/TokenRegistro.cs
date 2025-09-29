using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class TokenRegistro
{
    public long TokenId { get; set; }

    public string Token { get; set; } = null!;

    public string? NitEmpresa { get; set; }

    public string Tipo { get; set; } = null!;

    public bool Usado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaExpiracion { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
