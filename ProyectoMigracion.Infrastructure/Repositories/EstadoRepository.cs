using Microsoft.EntityFrameworkCore;
using ProyectoMigracion.Core.Entities;
using ProyectoMigracion.Core.Interfaces;
using ProyectoMigracion.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoMigracion.Infrastructure.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly ProyectoMigracionContext _context;
        public EstadoRepository(ProyectoMigracionContext context)
        {
            _context = context;
        }
        public async Task<List<Estado>> GetEstados()
        {
            return await _context.Estados.ToListAsync();
        }
        public async Task<Estado> GetEstado(string nombreEstado)
        {
            return await _context.Estados.FirstOrDefaultAsync( x => x.NombreEstado == nombreEstado );
        }
        public async Task AddEstado(Estado estado)
        {
            _context.Estados.Add(estado);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateEstado(Estado estado)
        {
            _context.Entry(estado).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0; 
        }
        public async Task<bool> DeleteEstado(Estado estado)
        {
            _context.Remove(estado);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
