using ProyectoMigracion.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoMigracion.Core.Interfaces
{
    public interface ISolicitudRepository
    {
        Task<List<Solicitud>> GetSolicitudes();
        Task<Solicitud> GetSolicitud(int id);
        Task AddSolicitud(Solicitud solicitud);
        Task<bool> UpdateSolicitud(Solicitud solicitud);
        Task<bool> DeleteSolicitud(Solicitud solicitud);
    }
}
