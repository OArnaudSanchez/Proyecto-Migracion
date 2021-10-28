using System.Collections.Generic;

namespace ProyectoMigracion.Core.Entities
{
    public partial class Estado
    {
        public Estado()
        {
            Equipos = new List<Equipo>();
            Solicitudes = new List<Solicitud>();
        }

        public string NombreEstado { get; set; }
        public virtual List<Equipo> Equipos { get; set; }
        public virtual List<Solicitud> Solicitudes { get; set; }
    }
}
