using System;

namespace ProyectoMigracion.Core.DTOs
{
    public class SolicitudDTO
    {
        public int Id { get; set; }
        public string NombreEstado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? PersonaId { get; set; }
    }
}
