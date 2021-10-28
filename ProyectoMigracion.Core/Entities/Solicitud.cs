using System;

namespace ProyectoMigracion.Core.Entities
{
    public partial class Solicitud
    {
        public int Id { get; set; }
        public string NombreEstado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? PersonaId { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
