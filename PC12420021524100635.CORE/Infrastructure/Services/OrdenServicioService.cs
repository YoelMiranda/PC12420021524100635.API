using PC12420021524100635.CORE.Core;
using PC12420021524100635.CORE.Core.DTOs;
using PC12420021524100635.CORE.Core.Interfaces;

namespace PC12420021524100635.CORE.Infrastructure.Services
{
    public class OrdenServicioService : IOrdenServicioService
    {
        private readonly IOrdenServicioRepository _ordenServicioRepository;

        public OrdenServicioService(IOrdenServicioRepository ordenServicioRepository)
        {
            _ordenServicioRepository = ordenServicioRepository;
        }

        public async Task<IEnumerable<OrdenServicioListDTO>> GetAll()
        {
            var ordenes = await _ordenServicioRepository.GetAll();
            var ordenesDTOs = new List<OrdenServicioListDTO>();

            foreach (var orden in ordenes)
            {
                ordenesDTOs.Add(MapToDTO(orden));
            }
            return ordenesDTOs;
        }

        public async Task<OrdenServicioListDTO> GetById(int id)
        {
            var orden = await _ordenServicioRepository.GetById(id);
            if (orden == null) return null;
            return MapToDTO(orden);
        }

        public async Task Create(OrdenServicioCreateDTO createDTO)
        {
            var orden = new OrdenServicio
            {
                FechaIngreso = DateTime.Now,
                DescripcionProblema = createDTO.DescripcionProblema,
                CostoEstimado = createDTO.CostoEstimado,
                Estado = createDTO.Estado,
                VehiculoId = createDTO.VehiculoId,
                TipoServicioId = createDTO.TipoServicioId
            };
            await _ordenServicioRepository.Create(orden);
        }

        public async Task Update(OrdenServicioUpdateDTO updateDTO)
        {
            var existing = await _ordenServicioRepository.GetById(updateDTO.Id);
            if (existing != null)
            {
                existing.DescripcionProblema = updateDTO.DescripcionProblema;
                existing.CostoEstimado = updateDTO.CostoEstimado;
                existing.Estado = updateDTO.Estado;
                existing.VehiculoId = updateDTO.VehiculoId;
                existing.TipoServicioId = updateDTO.TipoServicioId;
                await _ordenServicioRepository.Update(existing);
            }
        }

        public async Task Delete(int id)
        {
            await _ordenServicioRepository.Delete(id);
        }

        private static OrdenServicioListDTO MapToDTO(OrdenServicio orden)
        {
            return new OrdenServicioListDTO
            {
                Id = orden.Id,
                FechaIngreso = orden.FechaIngreso,
                DescripcionProblema = orden.DescripcionProblema,
                CostoEstimado = orden.CostoEstimado,
                Estado = orden.Estado,
                VehiculoId = orden.VehiculoId,
                TipoServicioId = orden.TipoServicioId,
                PlacaVehiculo = orden.Vehiculo?.Placa,
                TipoServicioNombre = orden.TipoServicio?.Nombre
            };
        }
    }
}
