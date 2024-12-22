namespace Medical.Office.App.Dtos.EspressPos.Viesw;

public record DetalleDeVentasDto(

    int VentaID,
    DateTime? FechaHora,
    string Producto,
    int Cantidad,
    double Subtotal
);