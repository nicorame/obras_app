namespace api.Dtos;

public class AlbanilesDto
{
    public Guid Id { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string Dni { get; set; }

    public string Telefono { get; set; }

    public string Calle { get; set; }

    public string Numero { get; set; }

    public string CodPost { get; set; }

    public bool Activo { get; set; }

    public DateOnly? FechaAlta { get; set; }
}