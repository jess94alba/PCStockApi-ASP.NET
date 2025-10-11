using Microsoft.EntityFrameworkCore;
using PCStockApi.Models;

namespace PCStockApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets: cada entidad representa una tabla en la BD
        public DbSet<Board> Boards { get; set; }
        public DbSet<Chasi> Chasis { get; set; }
        public DbSet<DetallePedido> DetallesPedido { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Disco> Discos { get; set; }
        public DbSet<Ensamblaje> Ensamblajes { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Formato> Formatos { get; set; }
        public DbSet<Fuente> Fuentes { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Pantalla> Pantallas { get; set; }
        public DbSet<Refrigeracion> Refrigeraciones { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoEnsamblaje> PedidoEnsamblajes { get; set; }
        public DbSet<Potencium> Potencias { get; set; }
        public DbSet<PrecioProducto> PrecioProductos { get; set; }
        public DbSet<Procesador> Procesadores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ProductoCompatible> ProductosCompatibles { get; set; }
        public DbSet<Ram> Rams { get; set; }
        public DbSet<RoleName> RoleNames { get; set; }
        public DbSet<Socket> Sockets { get; set; }
        public DbSet<TarjetaVideo> TarjetaVideos { get; set; }
        public DbSet<TipoDisco> TiposDisco { get; set; }
        public DbSet<TipoMemorium> TiposMemoria { get; set; }
        public DbSet<TipoProducto> TiposProducto { get; set; }
        public DbSet<TipoRefrigeracion> TiposRefrigeracion { get; set; }
        public DbSet<TokenRegistro> TokenRegistros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioRole> UsuarioRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Clave primaria de Board
            modelBuilder.Entity<Board>()
                .HasKey(b => b.BoardId);
            // Clave primaria de Chasis
            modelBuilder.Entity<Chasi>()
                .HasKey(c => c.ChasisId);
            // Clave primaria de DetallePedido
            modelBuilder.Entity<DetallePedido>()
                .HasKey(de => de.DetalleId);
            // Clave primaria de Direccion
            modelBuilder.Entity<Direccion>()
                .HasKey(d => d.DireccionId);
            // Clave primaria de Disco
            modelBuilder.Entity<Disco>()
                .HasKey(di => di.DiscoId);
            // Clave primaria de Ensamblaje
            modelBuilder.Entity<Ensamblaje>()
                .HasKey(e => e.EnsamblajeId);
            // Clave primaria de Envio
            modelBuilder.Entity<Envio>()
                .HasKey(en => en.EnvioId);
            // Clave primaria de Formato
            modelBuilder.Entity<Formato>()
                .HasKey(f => f.FormatoId);
            // Clave primaria de Fuente
            modelBuilder.Entity<Fuente>()
                .HasKey(fu => fu.FuenteId);
            // Clave primaria de Inventario
            modelBuilder.Entity<Inventario>()
                .HasKey(i => i.InventarioId);
            // Clave primaria de Marca
            modelBuilder.Entity<Marca>()
                .HasKey(m => m.MarcaId);
            // Clave primaria de Pantalla
            modelBuilder.Entity<Pantalla>()
                .HasKey(p => p.MonitorId);
            // Clave primaria de Pedido
            modelBuilder.Entity<Pedido>()
                .HasKey(pe => pe.PedidoId);
            // Clave primaria de Refrigeracion
            modelBuilder.Entity<Refrigeracion>()
                .HasKey(r => r.RefrigeracionId);
            // Clave primaria de PedidoEnsamblaje
            modelBuilder.Entity<PedidoEnsamblaje>()
                .HasKey(pen => pen.Id);
            // Clave primaria de Potnecium
            modelBuilder.Entity<Potencium>()
                .HasKey(po => po.PotenciaId);
            // Clave primaria de PrecioProducto
            modelBuilder.Entity<PrecioProducto>()
                .HasKey(pr => pr.PrecioId);
            // Clave primaria de Procesador
            modelBuilder.Entity<Procesador>()
                .HasKey(pro => pro.ProcesadorId);
            // Clave primaria de Producto
            modelBuilder.Entity<Producto>()
                .HasKey(prod => prod.ProductoId);
            // Clave primaria de ProductoCompatible
            modelBuilder.Entity<ProductoCompatible>()
                .HasKey(pco => pco.ProductoCompatibleId);
            // Clave primaria de Ram
            modelBuilder.Entity<Ram>()
                .HasKey(r => r.RamId);
            // Clave Primaria de Refrigeracion
            modelBuilder.Entity<Refrigeracion>()
                .HasKey(re => re.RefrigeracionId);
            // Clave primaria de RoleName
            modelBuilder.Entity<RoleName>()
                .HasKey(rn => rn.RoleId);
            // Clave primaria de Socket
            modelBuilder.Entity<Socket>()
                .HasKey(s => s.SocketId);
            // Clave primaria de TarjetaVideo
            modelBuilder.Entity<TarjetaVideo>()
                .HasKey(tv => tv.TarjetaId);
            // Clave primaria de TipoDisco
            modelBuilder.Entity<TipoDisco>()
                .HasKey(td => td.TipoDiscoId);
            // Clave primaria de TipoMemoria
            modelBuilder.Entity<TipoMemorium>()
                .HasKey(tm => tm.TipoMemoriaId);
            // Clave primaria de TipoProducto
            modelBuilder.Entity<TipoProducto>()
                .HasKey(tp => tp.TipoId);
            // Clave primaria de TipoRefrigeracion
            modelBuilder.Entity<TipoRefrigeracion>()
                .HasKey(tr => tr.TipoRefrigeracionId);
            // Clave primaria de TokenRegistro
            modelBuilder.Entity<TokenRegistro>()
                .HasKey(tk => tk.TokenId);
            // Clave primaria de Usuario
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.UsuarioId);
            // Clave primaria de UsuarioRole
            modelBuilder.Entity<UsuarioRole>()
                .HasKey(ur => ur.UsuarioRoleId);

            // Relación: Producto → ProductoCompatible (Producto principal)
            modelBuilder.Entity<ProductoCompatible>()
                .HasOne(pc => pc.Producto)  // Relación con Producto principal
                .WithMany(p => p.ProductoCompatibleProductos) // Lista en Producto
                .HasForeignKey(pc => pc.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación: ProductoCompatibleCon → ProductoCompatible (Producto secundario/compatible)
            modelBuilder.Entity<ProductoCompatible>()
                .HasOne(pc => pc.ProductoCompatibleCon) // Relación con producto compatible
                .WithMany(p => p.ProductoCompatibleProductoCompatibleCons) // Lista en Producto
                .HasForeignKey(pc => pc.ProductoCompatibleConId)
                .OnDelete(DeleteBehavior.Restrict);             
        }
    }
}
