using System;
using System.Collections.Generic;

namespace ProyectoMigracion.Core.Entities
{
    public partial class Persona
    {
        public Persona()
        {
            Equipos = new List<Equipo>();
            Solicitudes = new List<Solicitud>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Pasaporte { get; set; }
        public string Direccion { get; set; }
        public string Sexo { get; set; }
        public string Foto { get; set; }
        public virtual List<Equipo> Equipos { get; set; }
        public virtual List<Solicitud> Solicitudes { get; set; }
    }
}
