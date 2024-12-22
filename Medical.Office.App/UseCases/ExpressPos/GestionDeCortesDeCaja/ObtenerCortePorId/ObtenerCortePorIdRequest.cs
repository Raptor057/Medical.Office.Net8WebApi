using Common.Common.CleanArch;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerCortePorId;

public record ObtenerCortePorIdRequest(int CorteID) : IRequest<ObtenerCortePorIdResponse>;