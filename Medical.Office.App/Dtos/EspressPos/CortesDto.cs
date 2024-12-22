namespace Medical.Office.App.Dtos.EspressPos;

public record CortesDto(

    int CorteID,
    DateTime? FechaHora,
    double TotalVendido,
    int TotalVentas
);