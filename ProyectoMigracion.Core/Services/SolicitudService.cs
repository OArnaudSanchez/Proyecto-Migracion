using ProyectoMigracion.Core.Entities;
using ProyectoMigracion.Core.Exceptions;
using ProyectoMigracion.Core.Interfaces;
using ProyectoMigracion.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMigracion.Core.Services
{
    public class SolicitudService : ISolicitudService
    {
        private readonly ISolicitudRepository _solicitudRepository;
        private readonly IPersonaService _personaService;
        private readonly IEstadoService _estadoService;
        public SolicitudService(ISolicitudRepository solicitudRepository, IPersonaService personaService, IEstadoService estadoService)
        {
            _solicitudRepository = solicitudRepository;
            _personaService = personaService;
            _estadoService = estadoService;
        }
        public async Task<List<Solicitud>> GetSolicitudes(SolicitudQueryFilter filters)
        {
            var solicitudes = await _solicitudRepository.GetSolicitudes();
            solicitudes = filters.IdSolicitud > 0 ? solicitudes.Where(x => x.Id == filters.IdSolicitud).ToList() : solicitudes;
            solicitudes = filters.NombreEstado != null ? solicitudes.Where(x => x.NombreEstado.ToUpper().Contains(filters.NombreEstado.ToUpper())).ToList() : solicitudes;
            return solicitudes;
        }
        public async Task<Solicitud> GetSolicitud(int id)
        {
            return await _solicitudRepository.GetSolicitud(id) ?? throw new ApiException("Solicitud No Encontrada", 404);
        }

        public async Task AddSolicitud(Solicitud solicitud)
        {
            if (solicitud == null) throw new ApiException("Parametro Invalido", 400);

            var currentPersona = await _personaService.GetPersona(solicitud.PersonaId.Value);
            var currentEstado = await _estadoService.GetEstado(solicitud.NombreEstado);

            solicitud.PersonaId = currentPersona.Id;
            solicitud.NombreEstado = currentEstado.NombreEstado?.ToUpper();
            solicitud.FechaCreacion = DateTime.Now;
            solicitud.Id = 0;

            await _solicitudRepository.AddSolicitud(solicitud);
        }
        public async Task<bool> UpdateSolicitud(Solicitud solicitud)
        {
            if (solicitud == null) throw new ApiException("Parametro Invalido", 400);

            var currentSolicitud = await GetSolicitud(solicitud.Id);
            var currentEstado = await _estadoService.GetEstado(solicitud.NombreEstado);

            currentSolicitud.NombreEstado = currentEstado.NombreEstado?.ToUpper();
            currentSolicitud.FechaCreacion = solicitud.FechaCreacion ?? currentSolicitud.FechaCreacion;
            return await _solicitudRepository.UpdateSolicitud(currentSolicitud);
        }
        public async Task<bool> DeleteSolicitud(int id)
        {
            var currentSolicitud = await GetSolicitud(id);
            return await _solicitudRepository.DeleteSolicitud(currentSolicitud);
        }
    }
}
