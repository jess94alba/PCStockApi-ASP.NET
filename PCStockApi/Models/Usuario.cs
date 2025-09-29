using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class Usuario
{
    public long UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? NitEmpresa { get; set; }

    public string? Telefono { get; set; }

    public bool EsAdmin { get; set; }

    public long? TokenUsadoId { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public virtual TokenRegistro? TokenUsado { get; set; }

    public virtual ICollection<UsuarioRole> UsuarioRoles { get; set; } = new List<UsuarioRole>();
}
