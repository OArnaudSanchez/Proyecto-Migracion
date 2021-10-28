using Microsoft.EntityFrameworkCore;
using ProyectoMigracion.Core.Entities;
using ProyectoMigracion.Core.Interfaces;
using ProyectoMigracion.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoMigracion.Infrastructure.Repositories
{
    public class SolicitudRepository : ISolicitudRepository
    {
        private readonly ProyectoMigracionContext _context;
        public SolicitudRepository(ProyectoMigracionContext context)
        {
            _context = context;
        }
        public async Task<List<Solicitud>> GetSolicitudes()
        {
            return await _context.Solicitudes.ToListAsync();
        }
        public async Task<Solicitud> GetSolicitud(int id)
        {
            return await _context.Solicitudes.FirstOrDefaultAsync( x => x.Id == id );
        }

        public async Task AddSolicitud(Solicitud solicitud)
        {
            _context.Solicitudes.Add(solicitud);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateSolicitud(Solicitud solicitud)
        {
            _context.Entry(solicitud).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteSolicitud(Solicitud solicitud)
        {
            _context.Solicitudes.Remove(solicitud);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
