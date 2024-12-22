using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerProductoPorId.Request;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerProductoPorId;

public record ObtenerProductoPorIdRequest(int ProductoID) : IRequest<ObtenerProductoPorIdResponse>;