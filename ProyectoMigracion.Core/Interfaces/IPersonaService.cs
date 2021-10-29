using ProyectoMigracion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMigracion.Core.Interfaces
{
    public interface IPersonaService
    {
        Task<List<Persona>> GetPersonas(string fotoPath);
        Task<Persona> GetPersona(int id);
        Task AddPersona(Persona persona);
        Task<bool> UpdatePersona(Persona persona);
        Task<bool> DeletePersona(int id);
    }
}
