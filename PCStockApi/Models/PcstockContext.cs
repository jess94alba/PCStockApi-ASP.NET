using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PCStockApi.Models;

public partial class PcstockContext : DbContext
{
    public PcstockContext()
    {
    }

    public PcstockContext(DbContextOptions<PcstockContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Board> Boards { get; set; }

    public virtual DbSet<Chasi> Chases { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<Disco> Discos { get; set; }

    public virtual DbSet<Ensamblaje> Ensamblajes { get; set; }

    public virtual DbSet<Envio> Envios { get; set; }

    public virtual DbSet<Formato> Formatos { get; set; }

    public virtual DbSet<Fuente> Fuentes { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Pantalla> Pantallas { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidoEnsamblaje> PedidoEnsamblajes { get; set; }

    public virtual DbSet<Potencium> Potencia { get; set; }

    public virtual DbSet<PrecioProducto> PrecioProductos { get; set; }

    public virtual DbSet<Procesador> Procesadors { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoCompatible> ProductoCompatibles { get; set; }

    public virtual DbSet<Ram> Rams { get; set; }

    public virtual DbSet<Refrigeracion> Refrigeracions { get; set; }

    public virtual DbSet<RoleName> RoleNames { get; set; }

    public virtual DbSet<Socket> Sockets { get; set; }

    public virtual DbSet<TarjetaVideo> TarjetaVideos { get; set; }

    public virtual DbSet<TipoDisco> TipoDiscos { get; set; }

    public virtual DbSet<TipoMemorium> TipoMemoria { get; set; }

    public virtual DbSet<TipoProducto> TipoProductos { get; set; }

    public virtual DbSet<TipoRefrigeracion> TipoRefrigeracions { get; set; }

    public virtual DbSet<TokenRegistro> TokenRegistros { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRole> UsuarioRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=PCStock;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Board>(entity =>
        {
            entity.HasKey(e => e.BoardId).HasName("PK__Board__F9646BF2D8CBB4ED");

            entity.ToTable("Board");

            entity.HasIndex(e => e.ProductoId, "UQ__Board__A430AEA22A88DBA7").IsUnique();

            entity.Property(e => e.Almacenamiento).HasMaxLength(200);
            entity.Property(e => e.Chipset).HasMaxLength(200);
            entity.Property(e => e.Expansion).HasMaxLength(200);
            entity.Property(e => e.PuertosExternos).HasMaxLength(400);
            entity.Property(e => e.Video).HasMaxLength(200);

            entity.HasOne(d => d.Formato).WithMany(p => p.Boards)
                .HasForeignKey(d => d.FormatoId)
                .HasConstraintName("FK_Board_Formato");

            entity.HasOne(d => d.Producto).WithOne(p => p.Board)
                .HasForeignKey<Board>(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Board_Producto");

            entity.HasOne(d => d.Socket).WithMany(p => p.Boards)
                .HasForeignKey(d => d.SocketId)
                .HasConstraintName("FK_Board_Socket");

            entity.HasOne(d => d.TipoMemoria).WithMany(p => p.Boards)
                .HasForeignKey(d => d.TipoMemoriaId)
                .HasConstraintName("FK_Board_TipoMemoria");
        });

        modelBuilder.Entity<Chasi>(entity =>
        {
            entity.HasKey(e => e.ChasisId).HasName("PK__Chasis__54765DD2432FE7F5");

            entity.ToTable("Chasis");

            entity.HasIndex(e => e.ProductoId, "UQ__Chasis__A430AEA2288C5067").IsUnique();

            entity.Property(e => e.Formato).HasMaxLength(100);
            entity.Property(e => e.PuertosExternos).HasMaxLength(200);

            entity.HasOne(d => d.Producto).WithOne(p => p.Chasi)
                .HasForeignKey<Chasi>(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chasis_Producto");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.DetalleId).HasName("PK__DetalleP__6E19D6DA4824DB3B");

            entity.ToTable("DetallePedido");

            entity.Property(e => e.PrecioUnit).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Pedido).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detalle_Pedido");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detalle_Producto");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.DireccionId).HasName("PK__Direccio__68906D64700F0AB5");

            entity.ToTable("Direccion");

            entity.Property(e => e.Ciudad).HasMaxLength(150);
            entity.Property(e => e.CodigoPostal).HasMaxLength(20);
            entity.Property(e => e.Departamento).HasMaxLength(150);
            entity.Property(e => e.Direccion1)
                .HasMaxLength(500)
                .HasColumnName("Direccion");
            entity.Property(e => e.TelefonoContacto).HasMaxLength(50);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Direccion_Usuario");
        });

        modelBuilder.Entity<Disco>(entity =>
        {
            entity.HasKey(e => e.DiscoId).HasName("PK__Disco__A5A1B992986BDD54");

            entity.ToTable("Disco");

            entity.HasIndex(e => e.ProductoId, "UQ__Disco__A430AEA2188A63AE").IsUnique();

            entity.Property(e => e.Capacidad).HasMaxLength(50);
            entity.Property(e => e.Formato).HasMaxLength(100);
            entity.Property(e => e.Velocidad).HasMaxLength(100);

            entity.HasOne(d => d.Producto).WithOne(p => p.Disco)
                .HasForeignKey<Disco>(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Disco_Producto");

            entity.HasOne(d => d.TipoDisco).WithMany(p => p.Discos)
                .HasForeignKey(d => d.TipoDiscoId)
                .HasConstraintName("FK_Disco_TipoDisco");
        });

        modelBuilder.Entity<Ensamblaje>(entity =>
        {
            entity.HasKey(e => e.EnsamblajeId).HasName("PK__Ensambla__2D9EB68775392282");

            entity.ToTable("Ensamblaje");

            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .HasDefaultValue("PENDIENTE");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Ensamblajes)
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("FK_Ensamblaje_Pedido");
        });

        modelBuilder.Entity<Envio>(entity =>
        {
            entity.HasKey(e => e.EnvioId).HasName("PK__Envio__D024E23F547F1B1D");

            entity.ToTable("Envio");

            entity.Property(e => e.EstadoEnvio)
                .HasMaxLength(100)
                .HasDefaultValue("PENDIENTE");
            entity.Property(e => e.Tracking).HasMaxLength(200);

            entity.HasOne(d => d.Direccion).WithMany(p => p.Envios)
                .HasForeignKey(d => d.DireccionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Envio_Direccion");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Envios)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Envio_Pedido");
        });

        modelBuilder.Entity<Formato>(entity =>
        {
            entity.HasKey(e => e.FormatoId).HasName("PK__Formato__D229F1D526E49586");

            entity.ToTable("Formato");

            entity.HasIndex(e => e.Nombre, "UQ__Formato__75E3EFCF7BF8F8DF").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Fuente>(entity =>
        {
            entity.HasKey(e => e.FuenteId).HasName("PK__Fuente__20861036DA1C60C8");

            entity.ToTable("Fuente");

            entity.HasIndex(e => e.ProductoId, "UQ__Fuente__A430AEA212407B7E").IsUnique();

            entity.Property(e => e.Certificacion).HasMaxLength(50);
            entity.Property(e => e.Protecciones).HasMaxLength(200);
            entity.Property(e => e.Ventilador).HasMaxLength(100);

            entity.HasOne(d => d.Potencia).WithMany(p => p.Fuentes)
                .HasForeignKey(d => d.PotenciaId)
                .HasConstraintName("FK_Fuente_Potencia");

            entity.HasOne(d => d.Producto).WithOne(p => p.Fuente)
                .HasForeignKey<Fuente>(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fuente_Producto");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.InventarioId).HasName("PK__Inventar__FB8A24D7326D50B3");

            entity.ToTable("Inventario");

            entity.Property(e => e.FechaMovimiento).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Observacion).HasMaxLength(400);
            entity.Property(e => e.TipoMovimiento).HasMaxLength(50);

            entity.HasOne(d => d.Producto).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventario_Producto");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.MarcaId).HasName("PK__Marca__D5B1CD8BC72C0DD5");

            entity.ToTable("Marca");

            entity.HasIndex(e => e.Nombre, "UQ__Marca__75E3EFCF4BC710BB").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(150);
        });

        modelBuilder.Entity<Pantalla>(entity =>
        {
            entity.HasKey(e => e.MonitorId).HasName("PK__Monitor__DF5D95F81134C1C9");

            entity.ToTable("Monitor");

            entity.HasIndex(e => e.ProductoId, "UQ__Monitor__A430AEA23014ACA6").IsUnique();

            entity.Property(e => e.Conexion).HasMaxLength(200);
            entity.Property(e => e.Curvatura).HasMaxLength(100);
            entity.Property(e => e.Panel).HasMaxLength(100);
            entity.Property(e => e.Resolucion).HasMaxLength(100);
            entity.Property(e => e.Respuesta).HasMaxLength(100);

            entity.HasOne(d => d.Producto).WithOne(p => p.Pantalla)
                .HasForeignKey<Pantalla>(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Monitor_Producto");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.PedidoId).HasName("PK__Pedido__09BA14302375951C");

            entity.ToTable("Pedido");

            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.Fecha).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedido_Usuario");
        });

        modelBuilder.Entity<PedidoEnsamblaje>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pedido_E__3214EC07CD4D8361");

            entity.ToTable("Pedido_Ensamblaje");

            entity.HasIndex(e => new { e.PedidoId, e.EnsamblajeId }, "UQ_Pedido_Ensamblaje").IsUnique();

            entity.HasOne(d => d.Ensamblaje).WithMany(p => p.PedidoEnsamblajes)
                .HasForeignKey(d => d.EnsamblajeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PE_Ensamblaje");

            entity.HasOne(d => d.Pedido).WithMany(p => p.PedidoEnsamblajes)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PE_Pedido");
        });

        modelBuilder.Entity<Potencium>(entity =>
        {
            entity.HasKey(e => e.PotenciaId).HasName("PK__Potencia__C4846F6AE200203D");
        });

        modelBuilder.Entity<PrecioProducto>(entity =>
        {
            entity.HasKey(e => e.PrecioId).HasName("PK__PrecioPr__061E65544D61A8E9");

            entity.ToTable("PrecioProducto");

            entity.HasIndex(e => e.ProductoId, "IDX_PrecioProducto_Producto");

            entity.Property(e => e.FechaInicio).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.PrecioBase).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Producto).WithMany(p => p.PrecioProductos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PrecioProducto_Producto");
        });

        modelBuilder.Entity<Procesador>(entity =>
        {
            entity.HasKey(e => e.ProcesadorId).HasName("PK__Procesad__CEC2B1559113EFEA");

            entity.ToTable("Procesador");

            entity.HasIndex(e => e.ProductoId, "UQ__Procesad__A430AEA21D90CEBC").IsUnique();

            entity.Property(e => e.Arquitectura).HasMaxLength(100);
            entity.Property(e => e.Bus).HasMaxLength(100);
            entity.Property(e => e.Cache).HasMaxLength(100);
            entity.Property(e => e.Consumo).HasMaxLength(100);
            entity.Property(e => e.GraficaIntegrada).HasMaxLength(200);
            entity.Property(e => e.Tecnologia).HasMaxLength(200);
            entity.Property(e => e.Velocidad).HasMaxLength(100);

            entity.HasOne(d => d.Producto).WithOne(p => p.Procesador)
                .HasForeignKey<Procesador>(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Procesador_Producto");

            entity.HasOne(d => d.Socket).WithMany(p => p.Procesadors)
                .HasForeignKey(d => d.SocketId)
                .HasConstraintName("FK_Procesador_Socket");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__A430AEA316AEA31D");

            entity.ToTable("Producto");

            entity.HasIndex(e => e.ProveedorId, "IDX_Producto_Proveedor");

            entity.HasIndex(e => e.TipoId, "IDX_Producto_Tipo");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Referencia).HasMaxLength(200);
            entity.Property(e => e.ValorCompra).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Marca).WithMany(p => p.Productos)
                .HasForeignKey(d => d.MarcaId)
                .HasConstraintName("FK_Producto_Marca");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Productos)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("FK_Producto_Proveedor");

            entity.HasOne(d => d.Tipo).WithMany(p => p.Productos)
                .HasForeignKey(d => d.TipoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_Tipo");
        });

        modelBuilder.Entity<ProductoCompatible>(entity =>
        {
            entity.HasKey(e => e.ProductoCompatibleId).HasName("PK__Producto__652B6B8323C8D2CF");

            entity.ToTable("Producto_Compatible");

            entity.HasIndex(e => new { e.ProductoId, e.ProductoCompatibleConId, e.TipoRelacion }, "UQ_Producto_Compatible").IsUnique();

            entity.Property(e => e.TipoRelacion).HasMaxLength(100);

            entity.HasOne(d => d.ProductoCompatibleCon).WithMany(p => p.ProductoCompatibleProductoCompatibleCons)
                .HasForeignKey(d => d.ProductoCompatibleConId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PC_Compatible");

            entity.HasOne(d => d.Producto).WithMany(p => p.ProductoCompatibleProductos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PC_Producto");
        });

        modelBuilder.Entity<Ram>(entity =>
        {
            entity.HasKey(e => e.RamId).HasName("PK__Ram__8840B277F75886BD");

            entity.ToTable("Ram");

            entity.HasIndex(e => e.ProductoId, "UQ__Ram__A430AEA21ACA3FCE").IsUnique();

            entity.Property(e => e.CapacidadGb).HasColumnName("CapacidadGB");
            entity.Property(e => e.Disipador).HasMaxLength(100);
            entity.Property(e => e.Formato).HasMaxLength(100);
            entity.Property(e => e.Latencia).HasMaxLength(100);
            entity.Property(e => e.Rgb)
                .HasMaxLength(10)
                .HasColumnName("RGB");
            entity.Property(e => e.Velocidad).HasMaxLength(100);
            entity.Property(e => e.Voltaje).HasMaxLength(50);

            entity.HasOne(d => d.Producto).WithOne(p => p.Ram)
                .HasForeignKey<Ram>(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ram_Producto");

            entity.HasOne(d => d.TipoMemoria).WithMany(p => p.Rams)
                .HasForeignKey(d => d.TipoMemoriaId)
                .HasConstraintName("FK_Ram_TipoMemoria");
        });

        modelBuilder.Entity<Refrigeracion>(entity =>
        {
            entity.HasKey(e => e.RefrigeracionId).HasName("PK__Refriger__256E59AA39AB534A");

            entity.ToTable("Refrigeracion");

            entity.HasIndex(e => e.ProductoId, "UQ__Refriger__A430AEA2E080DF9A").IsUnique();

            entity.Property(e => e.CompatibilidadExtra).HasMaxLength(200);
            entity.Property(e => e.Iluminacion).HasMaxLength(100);
            entity.Property(e => e.TamanoRadiador).HasMaxLength(100);
            entity.Property(e => e.Ventiladores).HasMaxLength(200);

            entity.HasOne(d => d.Producto).WithOne(p => p.Refrigeracion)
                .HasForeignKey<Refrigeracion>(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Refrigeracion_Producto");

            entity.HasOne(d => d.SocketCompatible).WithMany(p => p.Refrigeracions)
                .HasForeignKey(d => d.SocketCompatibleId)
                .HasConstraintName("FK_Refrigeracion_Socket");

            entity.HasOne(d => d.TipoRefrigeracion).WithMany(p => p.Refrigeracions)
                .HasForeignKey(d => d.TipoRefrigeracionId)
                .HasConstraintName("FK_Refrigeracion_Tipo");
        });

        modelBuilder.Entity<RoleName>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__RoleName__8AFACE1ABA5CFA56");

            entity.ToTable("RoleName");

            entity.HasIndex(e => e.Nombre, "UQ__RoleName__75E3EFCFC27940F0").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Socket>(entity =>
        {
            entity.HasKey(e => e.SocketId).HasName("PK__Socket__A1A1721FBB63DB53");

            entity.ToTable("Socket");

            entity.HasIndex(e => e.Nombre, "UQ__Socket__75E3EFCF529C3086").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<TarjetaVideo>(entity =>
        {
            entity.HasKey(e => e.TarjetaId).HasName("PK__TarjetaV__C82507764125CE10");

            entity.ToTable("TarjetaVideo");

            entity.HasIndex(e => e.ProductoId, "UQ__TarjetaV__A430AEA2B2E8C492").IsUnique();

            entity.Property(e => e.Chipset).HasMaxLength(200);
            entity.Property(e => e.Memoria).HasMaxLength(100);

            entity.HasOne(d => d.PotenciaRequerida).WithMany(p => p.TarjetaVideos)
                .HasForeignKey(d => d.PotenciaRequeridaId)
                .HasConstraintName("FK_Tarjeta_Potencia");

            entity.HasOne(d => d.Producto).WithOne(p => p.TarjetaVideo)
                .HasForeignKey<TarjetaVideo>(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tarjeta_Producto");
        });

        modelBuilder.Entity<TipoDisco>(entity =>
        {
            entity.HasKey(e => e.TipoDiscoId).HasName("PK__TipoDisc__50535AB075733D68");

            entity.ToTable("TipoDisco");

            entity.HasIndex(e => e.Nombre, "UQ__TipoDisc__75E3EFCFE83E2731").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<TipoMemorium>(entity =>
        {
            entity.HasKey(e => e.TipoMemoriaId).HasName("PK__TipoMemo__42E899BB9FCB48DF");

            entity.HasIndex(e => e.Nombre, "UQ__TipoMemo__75E3EFCFC59885EF").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<TipoProducto>(entity =>
        {
            entity.HasKey(e => e.TipoId).HasName("PK__TipoProd__97099EB709BB75D5");

            entity.ToTable("TipoProducto");

            entity.HasIndex(e => e.Nombre, "UQ__TipoProd__75E3EFCFCB6C7EF6").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<TipoRefrigeracion>(entity =>
        {
            entity.HasKey(e => e.TipoRefrigeracionId).HasName("PK__TipoRefr__1B9B19CB9915AD25");

            entity.ToTable("TipoRefrigeracion");

            entity.HasIndex(e => e.Nombre, "UQ__TipoRefr__75E3EFCF06CB15EC").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<TokenRegistro>(entity =>
        {
            entity.HasKey(e => e.TokenId).HasName("PK__TokenReg__658FEEEADD343951");

            entity.ToTable("TokenRegistro");

            entity.HasIndex(e => e.Token, "UQ__TokenReg__1EB4F8170D92ED9F").IsUnique();

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.NitEmpresa).HasMaxLength(50);
            entity.Property(e => e.Tipo).HasMaxLength(20);
            entity.Property(e => e.Token).HasMaxLength(100);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE7B83C21A603");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534135B64A0").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.NitEmpresa).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.PasswordHash).HasMaxLength(500);
            entity.Property(e => e.Telefono).HasMaxLength(50);

            entity.HasOne(d => d.TokenUsado).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.TokenUsadoId)
                .HasConstraintName("FK_Usuario_Token");
        });

        modelBuilder.Entity<UsuarioRole>(entity =>
        {
            entity.HasKey(e => e.UsuarioRoleId).HasName("PK__UsuarioR__7C696BD80728B151");

            entity.ToTable("UsuarioRole");

            entity.HasIndex(e => new { e.UsuarioId, e.RoleId }, "UQ_UsuarioRole").IsUnique();

            entity.HasOne(d => d.Role).WithMany(p => p.UsuarioRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRole_Role");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioRoles)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRole_Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
