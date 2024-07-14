using System;
using System.Collections.Generic;

namespace api.Models;

public partial class role
{
    public Guid Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? KeyRol { get; set; }

    public virtual ICollection<usuario> usuarios { get; set; } = new List<usuario>();
}
