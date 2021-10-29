using ProyectoMigracion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMigracion.Core.Interfaces
{
    public interface IEstadoService
    {
        Task<List<Estado>> GetEstados();
        Task<Estado> GetEstado(string nombre);
        Task AddEstado(Estado estado);
    }
}
