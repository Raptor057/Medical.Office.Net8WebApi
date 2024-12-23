namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeVentas.RegistrarVenta;

public class RegistrarVentaRequestBody
{
    public DateTime FechaHora { get; set; }
    public double Total { get; set; }
    public IEnumerable<(int ProductoID, int Cantidad)> Productos { get; set; }
}