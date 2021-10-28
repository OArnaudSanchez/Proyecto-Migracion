using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProyectoMigracion.Core.DTOs;
using ProyectoMigracion.Core.Entities;
using ProyectoMigracion.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMigracion.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitudesController : ControllerBase
    {
        private readonly ISolicitudService _solicitudService;
        private readonly IMapper _mapper;
        public SolicitudesController(ISolicitudService solicitudService, IMapper mapper)
        {
            _solicitudService = solicitudService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<SolicitudDTO>>> GetAll()
        {
            var solicitudes = await _solicitudService.GetSolicitudes();
            var solicitudesDTO = _mapper.Map<List<SolicitudDTO>>(solicitudes);
            return Ok(solicitudesDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitudDTO>> Get(int id)
        {
            var solicitud = await _solicitudService.GetSolicitud(id);
            var solicitudDTO = _mapper.Map<SolicitudDTO>(solicitud);
            return Ok(solicitudDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SolicitudDTO solicitudDTO)
        {
            var solicitud = _mapper.Map<Solicitud>(solicitudDTO);
            await _solicitudService.AddSolicitud(solicitud);
            solicitudDTO.Id = solicitud.Id;
            return Created(nameof(Get), new { id = solicitud.Id, solicitudDTO });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] SolicitudDTO solicitudDTO)
        {
            var solicitud = _mapper.Map<Solicitud>(solicitudDTO);
            solicitud.Id = id;
            await _solicitudService.UpdateSolicitud(solicitud);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _solicitudService.DeleteSolicitud(id);
            return NoContent();
        }
    }
}
