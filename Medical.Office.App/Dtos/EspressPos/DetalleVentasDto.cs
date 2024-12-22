namespace Medical.Office.App.Dtos.EspressPos;

public record DetalleVentasDto(

    int DetalleID,
    int VentaID,
    int ProductoID,
    int Cantidad,
    double Subtotal
);