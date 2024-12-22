using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerDetalleDeVentas.Response;

namespace Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerDetalleDeVentas;

public record ObtenerDetalleDeVentasRequest(int VentaID) : IRequest<ObtenerDetalleDeVentasResponse>;