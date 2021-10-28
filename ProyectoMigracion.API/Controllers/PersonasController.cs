using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProyectoMigracion.Core.DTOs;
using ProyectoMigracion.Core.Entities;
using ProyectoMigracion.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoMigracion.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaService _personaService;
        private readonly IMapper _mapper;
        public PersonasController(IPersonaService personaService, IMapper mapper)
        {
            _personaService = personaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonaDTO>>> GetAll()
        {
            var personas = await _personaService.GetPersonas();
            var personasDTO = _mapper.Map<List<PersonaDTO>>(personas);
            return Ok(personasDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaDTO>> Get(int id)
        {
            var persona = await _personaService.GetPersona(id);
            var personaDTO = _mapper.Map<PersonaDTO>(persona);
            return Ok(personaDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post(PersonaDTO personaDTO)
        {
            var persona = _mapper.Map<Persona>(personaDTO);
            await _personaService.AddPersona(persona);
            personaDTO.Id = persona.Id;
            return Created(nameof(Get), new { id = persona.Id, personaDTO });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, PersonaDTO personaDTO)
        {
            var persona = _mapper.Map<Persona>(personaDTO);
            persona.Id = id;
            await _personaService.UpdatePersona(persona);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _personaService.DeletePersona(id);
            return NoContent();
        }
    }
}
