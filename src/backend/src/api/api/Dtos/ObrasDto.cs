namespace api.Dtos;

public class ObrasDto
{
    public Guid Id { get; set; }

    public string Nombre { get; set; }

    public string DatosVarios { get; set; }

    public TipoObraDto IdTipoObraNavigation { get; set; }
    public int CantidadAlbaniles { get; set; }
}