using ProyectoMigracion.Core.Entities;
using ProyectoMigracion.Core.Exceptions;
using ProyectoMigracion.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMigracion.Core.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository;
        public EstadoService(IEstadoRepository estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }
        public async Task<List<Estado>> GetEstados()
        {
            return await _estadoRepository.GetEstados();
        }
        public async Task<Estado> GetEstado(string nombreEstado)
        {
            return await _estadoRepository.GetEstado(nombreEstado?.ToUpper()) ?? throw new ApiException("Estado No Encontrado", 404);
        }
        public async Task AddEstado(Estado estado)
        {
            if (estado == null) throw new ApiException("Parametro Invalido", 400);

            var estados = await GetEstados();
            if (estados.Where(x => x.NombreEstado.ToUpper() == estado.NombreEstado?.ToUpper()).Any())
                throw new ApiException("Este estado ya existe", 400);

            estado.NombreEstado = estado.NombreEstado?.ToUpper();
            await _estadoRepository.AddEstado(estado);
        }
    }
}
