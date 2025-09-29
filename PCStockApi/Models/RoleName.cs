using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class RoleName
{
    public long RoleId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<UsuarioRole> UsuarioRoles { get; set; } = new List<UsuarioRole>();
}
