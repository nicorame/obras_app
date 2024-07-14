using System;
using System.Collections.Generic;

namespace api.Models;

public partial class usuario
{
    public Guid Id { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public Guid? IdRol { get; set; }

    public bool? Activo { get; set; }

    public DateOnly? FechaAlta { get; set; }

    public DateOnly? FechaModificacion { get; set; }

    public string? Telefono { get; set; }

    public string? Calle { get; set; }

    public string? Numero { get; set; }

    public string? CodPost { get; set; }

    public string? Provincia { get; set; }

    public string? Ciudad { get; set; }

    public virtual role? IdRolNavigation { get; set; }
}
