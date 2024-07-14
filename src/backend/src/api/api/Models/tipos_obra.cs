using System;
using System.Collections.Generic;

namespace api.Models;

public partial class tipos_obra
{
    public Guid Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<obra> obras { get; set; } = new List<obra>();
}
