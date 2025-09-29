using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class Direccion
{
    public long DireccionId { get; set; }

    public long UsuarioId { get; set; }

    public string Direccion1 { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Departamento { get; set; } = null!;

    public string? CodigoPostal { get; set; }

    public string? TelefonoContacto { get; set; }

    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();

    public virtual Usuario Usuario { get; set; } = null!;
}
