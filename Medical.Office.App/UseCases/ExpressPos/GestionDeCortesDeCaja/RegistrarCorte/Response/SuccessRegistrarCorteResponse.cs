using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.RegistrarCorte.Response;

public record SuccessRegistrarCorteResponse(DateTime FechaHora, double TotalVendido, int TotalVentas) : RegistrarCorteResponse, ISuccess;