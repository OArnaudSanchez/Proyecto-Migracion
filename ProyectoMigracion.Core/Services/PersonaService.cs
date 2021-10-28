using ProyectoMigracion.Core.Entities;
using ProyectoMigracion.Core.Exceptions;
using ProyectoMigracion.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMigracion.Core.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        public PersonaService(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }
        public async Task<List<Persona>> GetPersonas(string fotoPath)
        {
            var personas = await _personaRepository.GetPersonas();
            personas = personas.Select(x => { x.Foto = string.Concat(fotoPath, "/", x.Foto); return x; }).ToList();
            return personas;
        }
        public async Task<Persona> GetPersona(int id)
        {
            return await _personaRepository.GetPersona(id) ?? throw new ApiException("Persona no Encontrada", 404);
        }
        public async Task AddPersona(Persona persona)
        {
            if (persona == null)
                throw new ApiException("Parametro Invalido", 400);

            persona.Id = 0;
            persona.Sexo = persona.Sexo?.ToUpper();
            var personas = await _personaRepository.GetPersonas();
            if (personas.Where(x => x.Pasaporte.ToLower() == persona.Pasaporte.ToLower()).Any())
                throw new ApiException("Ya existe una persona con este Pasaporte", 400);

            await _personaRepository.AddPersona(persona);
        }
        public async Task<bool> UpdatePersona(Persona persona)
        {
            if (persona == null)
                throw new ApiException("Parametro Invalido", 400);

            var currentPersona = await GetPersona(persona.Id);
            //Solo vamos a actualizar los campos que son modificables
            currentPersona.Pasaporte = persona.Pasaporte;
            currentPersona.Direccion = persona.Direccion;
            currentPersona.Sexo = persona.Sexo;
            currentPersona.Foto = persona.Foto;

            await _personaRepository.UpdatePersona(currentPersona);
            return true;
        }
        public async Task<bool> DeletePersona(int id)
        {
            var currentPersona = await GetPersona(id);
            await _personaRepository.DeletePersona(currentPersona);
            return true;
        }
    }
}
