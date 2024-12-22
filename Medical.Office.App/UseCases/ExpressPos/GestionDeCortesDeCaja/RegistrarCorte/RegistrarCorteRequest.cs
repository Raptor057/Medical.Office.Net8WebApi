using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.RegistrarCorte.Response;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.RegistrarCorte;

public record RegistrarCorteRequest(DateTime FechaHora, double TotalVendido, int TotalVentas) : IRequest<RegistrarCorteResponse>;