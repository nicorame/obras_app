namespace api.Dtos;

public class DeportesDto
{    
    public Guid Id { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public DateOnly FechaAlta { get; set; }
}