using System;
using System.Collections.Generic;

namespace PCStockApi.Models;

public partial class Producto
{
    public long ProductoId { get; set; }

    public long TipoId { get; set; }

    public long? MarcaId { get; set; }

    public string? Referencia { get; set; }

    public string? Caracteristicas { get; set; }

    public int Cantidad { get; set; }

    public decimal? ValorCompra { get; set; }

    public long? ProveedorId { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Board? Board { get; set; }

    public virtual Chasi? Chasi { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual Disco? Disco { get; set; }

    public virtual Fuente? Fuente { get; set; }

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual Marca? Marca { get; set; }

    public virtual Pantalla? Pantalla { get; set; }

    public virtual ICollection<PrecioProducto> PrecioProductos { get; set; } = new List<PrecioProducto>();

    public virtual Procesador? Procesador { get; set; }

    public virtual ICollection<ProductoCompatible> ProductoCompatibleProductoCompatibleCons { get; set; } = new List<ProductoCompatible>();

    public virtual ICollection<ProductoCompatible> ProductoCompatibleProductos { get; set; } = new List<ProductoCompatible>();

    public virtual Usuario? Proveedor { get; set; }

    public virtual Ram? Ram { get; set; }

    public virtual Refrigeracion? Refrigeracion { get; set; }

    public virtual TarjetaVideo? TarjetaVideo { get; set; }

    public virtual TipoProducto Tipo { get; set; } = null!;
}
