using PC12420021524100635.CORE.Core.DTOs;

namespace PC12420021524100635.CORE.Core.Interfaces
{
    public interface IOrdenServicioService
    {
        Task<IEnumerable<OrdenServicioListDTO>> GetAll();
        Task<OrdenServicioListDTO> GetById(int id);
        Task Create(OrdenServicioCreateDTO createDTO);
        Task Update(OrdenServicioUpdateDTO updateDTO);
        Task Delete(int id);
    }
}
