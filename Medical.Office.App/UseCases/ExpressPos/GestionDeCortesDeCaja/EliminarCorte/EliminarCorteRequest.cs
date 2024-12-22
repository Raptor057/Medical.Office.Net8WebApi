using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.EliminarCorte.Response;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.EliminarCorte;

public record EliminarCorteRequest(int CorteID) : IRequest<EliminarCorteResponse>;