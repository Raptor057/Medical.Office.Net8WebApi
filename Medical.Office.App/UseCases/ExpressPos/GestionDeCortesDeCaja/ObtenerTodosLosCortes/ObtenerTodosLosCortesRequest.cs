using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerTodosLosCortes.Response;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerTodosLosCortes;

public record ObtenerTodosLosCortesRequest() : IRequest<ObtenerTodosLosCortesResponse>;