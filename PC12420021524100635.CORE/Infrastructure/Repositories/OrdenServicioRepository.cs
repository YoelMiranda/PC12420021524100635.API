using Microsoft.EntityFrameworkCore;
using PC12420021524100635.CORE.Core;
using PC12420021524100635.CORE.Core.Interfaces;
using PC12420021524100635.CORE.Infrastructure.Data;

namespace PC12420021524100635.CORE.Infrastructure.Repositories
{
    public class OrdenServicioRepository : IOrdenServicioRepository
    {
        private readonly TallerMecanicoDbContext _context;

        public OrdenServicioRepository(TallerMecanicoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrdenServicio>> GetAll()
        {
            return await _context.OrdenServicios
                .Include(o => o.Vehiculo)
                .Include(o => o.TipoServicio)
                .ToListAsync();
        }

        public async Task<OrdenServicio> GetById(int id)
        {
            return await _context.OrdenServicios
                .Include(o => o.Vehiculo)
                .Include(o => o.TipoServicio)
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Create(OrdenServicio ordenServicio)
        {
            _context.OrdenServicios.Add(ordenServicio);
            await _context.SaveChangesAsync();
        }

        public async Task Update(OrdenServicio ordenServicio)
        {
            var existing = await _context.OrdenServicios
                .Where(o => o.Id == ordenServicio.Id)
                .FirstOrDefaultAsync();

            if (existing != null)
            {
                existing.DescripcionProblema = ordenServicio.DescripcionProblema;
                existing.CostoEstimado = ordenServicio.CostoEstimado;
                existing.Estado = ordenServicio.Estado;
                existing.VehiculoId = ordenServicio.VehiculoId;
                existing.TipoServicioId = ordenServicio.TipoServicioId;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var existing = await _context.OrdenServicios
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            if (existing != null)
            {
                _context.OrdenServicios.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }
    }
}
