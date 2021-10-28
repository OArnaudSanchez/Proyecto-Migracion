using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private readonly IHelperImage _helperImage;
        private string _directory;
        public PersonasController(IPersonaService personaService, IMapper mapper, IHelperImage helperImage, IWebHostEnvironment env)
        {
            _personaService = personaService;
            _mapper = mapper;
            _helperImage = helperImage;
            _directory = env.ContentRootPath;
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
        public async Task<ActionResult> Post([FromForm]PersonaDTO personaDTO)
        {
            personaDTO.Foto = await _helperImage.Upload(new List<IFormFile> { personaDTO.ImagenArchivo }, _directory);
            var persona = _mapper.Map<Persona>(personaDTO);
            await _personaService.AddPersona(persona);
            personaDTO.Id = persona.Id;
            return Created(nameof(Get), new { id = persona.Id, personaDTO });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm]PersonaDTO personaDTO)
        {
            await DeleteImage(id);
            personaDTO.Foto = await _helperImage.Upload(new List<IFormFile> { personaDTO.ImagenArchivo }, _directory);
            var persona = _mapper.Map<Persona>(personaDTO);
            persona.Id = id;
            await _personaService.UpdatePersona(persona);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _personaService.DeletePersona(id);
            await DeleteImage(id);
            return NoContent();
        }

        private async Task<bool> DeleteImage(int id)
        {
            var image = await _personaService.GetPersona(id);
            _helperImage.DeleteImage(image.Foto, _directory);
            return true;
        }
    }
}
