namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeProductos.ActualizarProducto;

public class ActualizarProductoRequestBody
{
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }
}