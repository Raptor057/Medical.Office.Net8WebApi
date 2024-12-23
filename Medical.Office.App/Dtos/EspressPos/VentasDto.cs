namespace Medical.Office.App.Dtos.EspressPos;

public record VentasDto(

    int VentaID,
    DateTime? FechaHora,
    double Total
);