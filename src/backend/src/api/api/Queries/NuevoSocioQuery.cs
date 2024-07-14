namespace api.Queries;

public class NuevoSocioQuery
{
    public string Email { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string Dni { get; set; }

    public Guid IdDeporte { get; set; }

    public string Telefono { get; set; }

    public string Calle { get; set; }

    public string Numero { get; set; }

    public string CodPost { get; set; }

    public string Provincia { get; set; }

    public string Ciudad { get; set; }
}