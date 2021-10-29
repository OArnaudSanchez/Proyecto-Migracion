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
    public class EstadosController : ControllerBase
    {
        private readonly IEstadoService _estadoService;
        private readonly IMapper _mapper;
        public EstadosController(IEstadoService estadoService, IMapper mapper)
        {
            _estadoService = estadoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EstadoDTO>>> GetAll()
        {
            var estados = await _estadoService.GetEstados();
            var estadosDTO = _mapper.Map<List<EstadoDTO>>(estados);
            return Ok(estadosDTO);
        }

        [HttpGet("{nombreEstado}")]
        public async Task<ActionResult<EstadoDTO>> Get(string nombreEstado)
        {
            var estado = await _estadoService.GetEstado(nombreEstado);
            var estadoDTO = _mapper.Map<EstadoDTO>(estado);
            return Ok(estadoDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EstadoDTO estadoDTO)
        {
            var estado = _mapper.Map<Estado>(estadoDTO);
            await _estadoService.AddEstado(estado);
            return Created(nameof(Get), new { nombreEstado = estadoDTO.NombreEstado?.ToUpper() });
        }
    }
}
