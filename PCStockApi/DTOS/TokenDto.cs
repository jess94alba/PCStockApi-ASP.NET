namespace PCStockApi.DTOs
{
    public class TokenDto
    {
        public string Token { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty; // "Proveedor" o "Vendedor"
        public string? NitEmpresa { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public bool Usado { get; set; }
    }
}
