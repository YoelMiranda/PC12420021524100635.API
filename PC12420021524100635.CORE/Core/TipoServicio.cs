using System;
using System.Collections.Generic;

namespace PC12420021524100635.CORE.Core;

public partial class TipoServicio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal PrecioBase { get; set; }

    public virtual ICollection<OrdenServicio> OrdenServicios { get; set; } = new List<OrdenServicio>();
}
