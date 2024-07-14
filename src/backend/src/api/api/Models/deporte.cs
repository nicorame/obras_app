using System;
using System.Collections.Generic;

namespace api.Models;

public partial class deporte
{
    public Guid Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? FechaAlta { get; set; }

    public virtual ICollection<socio> socios { get; set; } = new List<socio>();
}
