using System;
using System.Collections.Generic;

namespace api.Models;

public partial class albanile
{
    public Guid Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Dni { get; set; }

    public string? Telefono { get; set; }

    public string? Calle { get; set; }

    public string? Numero { get; set; }

    public string? CodPost { get; set; }

    public bool? Activo { get; set; }

    public DateOnly? FechaAlta { get; set; }

    public virtual ICollection<albaniles_x_obra> albaniles_x_obras { get; set; } = new List<albaniles_x_obra>();
}
