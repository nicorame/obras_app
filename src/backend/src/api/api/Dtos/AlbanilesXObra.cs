namespace api.Dtos;

public class AlbanilesXObra
{
    public Guid Id { get; set; }

    public Guid IdAlbanil { get; set; }

    public Guid IdObra { get; set; }

    public string TareaARealizar { get; set; }

    public DateOnly FechaAlta { get; set; }
}