using System;
using System.Collections.Generic;

namespace api.Models;

public partial class albaniles_x_obra
{
    public Guid Id { get; set; }

    public Guid? IdAlbanil { get; set; }

    public Guid? IdObra { get; set; }

    public string? TareaARealizar { get; set; }

    public DateOnly? FechaAlta { get; set; }

    public virtual albanile? IdAlbanilNavigation { get; set; }

    public virtual obra? IdObraNavigation { get; set; }
}
