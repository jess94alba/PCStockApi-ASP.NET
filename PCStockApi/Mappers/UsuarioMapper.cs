using PCStockApi.DTOs;
using PCStockApi.Models;
using System;
using System.Linq;

namespace PCStockApi.Mappers
{
    public static class UsuarioMapper
    {
        public static Usuario ToEntity(UsuarioDto dto)
        {
            return new Usuario
            {
                UsuarioId = dto.Id,
                Nombre = dto.Nombre,
                Email = dto.Correo,
                PasswordHash = dto.Password, // En el servicio se encripta
                NitEmpresa = dto.NitEmpresa,
                Telefono = dto.Telefono,
                FechaRegistro = dto.FechaRegistro ?? DateTime.Now,
                EsAdmin = dto.Rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase),
                TokenUsado = null // Se maneja desde TokenRepository
            };
        }

        public static UsuarioDto ToDto(Usuario usuario)
        {
            return new UsuarioDto
            {
                Id = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Correo = usuario.Email,
                NitEmpresa = usuario.NitEmpresa,
                Telefono = usuario.Telefono,
                FechaRegistro = usuario.FechaRegistro,
                Rol = usuario.EsAdmin ? "Administrador" :
                      usuario.UsuarioRoles.FirstOrDefault()?.Role.Nombre ?? "Cliente",
                RolesAsignados = usuario.UsuarioRoles.Select(r => r.Role.Nombre).ToList()
            };
        }
    }
}

