using System;

namespace ProyectoMigracion.Core.Entities
{
    public partial class Equipo
    {
        public int Id { get; set; }
        public int? PersonaId { get; set; }
        public string EstadoId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
