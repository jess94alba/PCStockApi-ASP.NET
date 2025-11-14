namespace PCStockApi.DTOs
{
    public class UsuarioDto
    {
        public long Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        // Contraseña en texto plano (solo para registrar o iniciar sesión)
        public string Password { get; set; } = string.Empty;

        // Solo aplica para proveedores o vendedores
        public string? NitEmpresa { get; set; }

        public string? Telefono { get; set; }

        // Rol general: "Cliente", "Proveedor", "Vendedor", "Administrador"
        public string Rol { get; set; } = string.Empty;

        // Token de invitación generado por el administrador
        public string? Token { get; set; }

        // Fecha de registro opcional (solo para mostrar)
        public DateTime? FechaRegistro { get; set; }

        // Roles asignados en la respuesta del backend
        public List<string>? RolesAsignados { get; set; }
    }
}
