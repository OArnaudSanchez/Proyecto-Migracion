using Microsoft.EntityFrameworkCore;
using ProyectoMigracion.Core.Entities;
using ProyectoMigracion.Core.Interfaces;
using ProyectoMigracion.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoMigracion.Infrastructure.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly ProyectoMigracionContext _context;
        public PersonaRepository(ProyectoMigracionContext context)
        {
            _context = context;
        }
        public async Task<List<Persona>> GetPersonas()
        {
            return await _context.Personas.ToListAsync();
        }
        public async Task<Persona> GetPersona(int id)
        {
            return await _context.Personas.FirstOrDefaultAsync( x => x.Id == id );
        }

        public async Task AddPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdatePersona(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeletePersona(Persona persona)
        {
            _context.Remove(persona);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
