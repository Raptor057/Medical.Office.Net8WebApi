namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeVentas.RegistrarVenta;

public class RegistrarVentaRequestBody
{
    public DateTime FechaHora { get; set; }
    //public double Total { get; set; }
    public IEnumerable<ProductoRequest> Productos { get; set; }
}

public class ProductoRequest
{
    public int ProductoID { get; set; }
    public int Cantidad { get; set; }
}
