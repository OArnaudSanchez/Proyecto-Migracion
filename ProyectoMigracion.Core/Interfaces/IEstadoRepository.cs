using ProyectoMigracion.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoMigracion.Core.Interfaces
{
    public interface IEstadoRepository
    {
        Task<List<Estado>> GetEstados();
        Task<Estado> GetEstado(string nombreEstado);
        Task AddEstado(Estado estado);
        Task<bool> UpdateEstado(Estado estado);
        Task<bool> DeleteEstado(Estado estado);
    }
}
