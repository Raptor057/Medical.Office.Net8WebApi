using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerTodosLosProductos.Response;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerTodosLosProductos;

public record ObtenerTodosLosProductosRequest() : IRequest<ObtenerTodosLosProductosResponse>;