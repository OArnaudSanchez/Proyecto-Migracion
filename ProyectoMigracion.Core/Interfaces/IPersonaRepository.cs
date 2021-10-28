using ProyectoMigracion.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoMigracion.Core.Interfaces
{
    public interface IPersonaRepository
    {
        Task<List<Persona>> GetPersonas();
        Task<Persona> GetPersona(int id);
        Task AddPersona(Persona persona);
        Task<bool> UpdatePersona(Persona persona);
        Task<bool> DeletePersona(Persona persona);
    }
}
