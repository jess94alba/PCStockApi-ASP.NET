namespace PCStockApi.DTOs
{
    public class UsuarioDto
    {
        public long Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        // Contraseña en texto plano al registrarse (se encripta antes de guardar)
        public string Password { get; set; } = string.Empty;

        // NIT solo aplica para proveedor y vendedor
        public string? NitEmpresa { get; set; }

        public string? Telefono { get; set; }

        // Rol: "Cliente", "Proveedor", "Vendedor" o "Administrador"
        public string Rol { get; set; } = string.Empty;

        // Token otorgado por el administrador (solo para proveedor o vendedor)
        public string? Token { get; set; }

        // Fecha de registro (opcional, lo puedes asignar desde el backend)
        public DateTime? FechaRegistro { get; set; }

        // En respuesta, el backend puede devolver roles asignados
        public List<string>? RolesAsignados { get; set; }
    }
}
