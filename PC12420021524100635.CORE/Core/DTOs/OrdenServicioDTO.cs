namespace PC12420021524100635.CORE.Core.DTOs
{
    public class OrdenServicioListDTO
    {
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string DescripcionProblema { get; set; } = null!;
        public decimal CostoEstimado { get; set; }
        public string Estado { get; set; } = null!;
        public int VehiculoId { get; set; }
        public int TipoServicioId { get; set; }
        public string? PlacaVehiculo { get; set; }
        public string? TipoServicioNombre { get; set; }
    }

    public class OrdenServicioCreateDTO
    {
        public string DescripcionProblema { get; set; } = null!;
        public decimal CostoEstimado { get; set; }
        public string Estado { get; set; } = null!;
        public int VehiculoId { get; set; }
        public int TipoServicioId { get; set; }
    }

    public class OrdenServicioUpdateDTO
    {
        public int Id { get; set; }
        public string DescripcionProblema { get; set; } = null!;
        public decimal CostoEstimado { get; set; }
        public string Estado { get; set; } = null!;
        public int VehiculoId { get; set; }
        public int TipoServicioId { get; set; }
    }
}
