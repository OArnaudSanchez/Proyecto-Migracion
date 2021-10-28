using ProyectoMigracion.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoMigracion.Core.Interfaces
{
    public interface ISolicitudService
    {
        Task<List<Solicitud>> GetSolicitudes();
        Task<Solicitud> GetSolicitud(int id);
        Task AddSolicitud(Solicitud solicitud);
        Task<bool> UpdateSolicitud(Solicitud solicitud);
        Task<bool> DeleteSolicitud(int id);
    }
}
