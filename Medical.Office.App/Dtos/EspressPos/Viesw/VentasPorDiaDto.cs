namespace Medical.Office.App.Dtos.EspressPos.Viesw;

public record VentasPorDiaDto(

    DateTime? Fecha,
    int? TotalVentas,
    decimal? TotalVendido
);