using ProyectoMigracion.Core.Entities;
using ProyectoMigracion.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoMigracion.Core.Interfaces
{
    public interface ISolicitudService
    {
        Task<List<Solicitud>> GetSolicitudes(SolicitudQueryFilter filers);
        Task<Solicitud> GetSolicitud(int id);
        Task AddSolicitud(Solicitud solicitud);
        Task<bool> UpdateSolicitud(Solicitud solicitud);
        Task<bool> DeleteSolicitud(int id);
    }
}
