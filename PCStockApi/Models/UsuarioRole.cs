using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class UsuarioRole
{
    public long UsuarioRoleId { get; set; }

    public long UsuarioId { get; set; }

    public long RoleId { get; set; }

    public virtual RoleName Role { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
