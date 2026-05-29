using PC12420021524100635.CORE.Core;

namespace PC12420021524100635.CORE.Core.Interfaces
{
    public interface IOrdenServicioRepository
    {
        Task<IEnumerable<OrdenServicio>> GetAll();
        Task<OrdenServicio> GetById(int id);
        Task Create(OrdenServicio ordenServicio);
        Task Update(OrdenServicio ordenServicio);
        Task Delete(int id);
    }
}
