using System;
using System.Collections.Generic;

namespace api.Models;

public partial class obra
{
    public Guid Id { get; set; }

    public string? Nombre { get; set; }

    public string? DatosVarios { get; set; }

    public Guid? IdTipoObra { get; set; }

    public virtual tipos_obra? IdTipoObraNavigation { get; set; }

    public virtual ICollection<albaniles_x_obra> albaniles_x_obras { get; set; } = new List<albaniles_x_obra>();
}
