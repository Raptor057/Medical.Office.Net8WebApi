namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeCortesDeCaja.RegistrarCorte;

public class RegistrarCorteRequestBody
{
    public DateTime FechaHora { get; set; }
    public double TotalVendido { get; set; }
    public int TotalVentas { get; set; }
}