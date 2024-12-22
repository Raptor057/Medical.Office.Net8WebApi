using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.ObtenerVentaPorId.Response;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.ObtenerVentaPorId;

public record ObtenerVentaPorIdRequest(int VentaID) : IRequest<ObtenerVentaPorIdResponse>;