using Medical.Office.Domain.Entities.ExpressPos;
using Medical.Office.Domain.Entities.ExpressPos.Views;

namespace Medical.Office.Domain.Repository;

public class POSInterfacesRepository
{
    /// <summary>
    /// Interface para operaciones relacionadas con los productos.
    /// </summary>
    public interface IProductoService
    {
        // CRUD
        Task AgregarProductoAsync(string nombre, double precio, int stock);
        Task ActualizarProductoAsync(int productoId, string nombre, double precio, int stock);
        Task EliminarProductoAsync(int productoId);
        Task<Productos> ObtenerProductoPorIdAsync(int productoId);
        Task<IEnumerable<Productos>> ObtenerTodosLosProductosAsync();

        // Operaciones adicionales
        Task ActualizarStockAsync(int productoId, int nuevoStock);
        Task<IEnumerable<Productos>> ObtenerProductosConBajoStockAsync(int limiteStock);
    }

    /// <summary>
    /// Interface para operaciones relacionadas con las ventas.
    /// </summary>
    public interface IVentaService
    {
        // CRUD
        Task<int> RegistrarVentaAsync(DateTime fechaHora, double total, IEnumerable<(int ProductoID, int Cantidad)> productos);
        Task EliminarVentaAsync(int ventaId);
        Task<Ventas> ObtenerVentaPorIdAsync(int ventaId);
        Task<IEnumerable<Ventas>> ObtenerVentasAsync();

        // Operaciones adicionales
        Task<IEnumerable<Ventas>> ObtenerVentasPorRangoAsync(DateTime fechaInicio, DateTime fechaFin);
        Task<IEnumerable<DetalleVentas>> ObtenerDetalleDeVentaAsync(int ventaId);
    }

    /// <summary>
    /// Interface para operaciones relacionadas con los cortes de caja.
    /// </summary>
    public interface ICorteService
    {
        // CRUD
        Task RegistrarCorteAsync(double totalVendido, int totalVentas);
        Task EliminarCorteAsync(int corteId);
        Task<Cortes> ObtenerCortePorIdAsync(int corteId);
        Task<IEnumerable<Cortes>> ObtenerCortesAsync();

        // Operaciones adicionales
        Task<IEnumerable<Cortes>> ObtenerCortesPorRangoAsync(DateTime fechaInicio, DateTime fechaFin);
    }

    /// <summary>
    /// Interface para reportes y vistas.
    /// </summary>
    public interface IReporteService
    {
        // Reportes
        Task<IEnumerable<VentasPorDia>> ObtenerVentasPorDiaAsync(DateTime fechaInicio, DateTime fechaFin);
        Task<IEnumerable<Cortes>> ObtenerResumenDeCortesPorDiaAsync(DateTime fechaInicio, DateTime fechaFin);
    }
}
