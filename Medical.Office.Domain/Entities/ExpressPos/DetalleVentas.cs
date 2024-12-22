namespace Medical.Office.Domain.Entities.ExpressPos;

public class DetalleVentas
{
    public int DetalleID { get; set; }

    public int VentaID { get; set; }

    public int ProductoID { get; set; }

    public int Cantidad { get; set; }

    public double Subtotal { get; set; }

}