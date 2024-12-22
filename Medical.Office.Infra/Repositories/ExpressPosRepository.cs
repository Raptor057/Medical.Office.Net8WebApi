using Medical.Office.Domain.Entities.ExpressPos;
using Medical.Office.Domain.Entities.ExpressPos.Views;
using Medical.Office.Domain.Repository;
using Medical.Office.Infra.DataSources;

namespace Medical.Office.Infra.Repositories;

public class ExpressPosRepository : POSInterfacesRepository.IProductoService, POSInterfacesRepository.IVentaService, POSInterfacesRepository.ICorteService, POSInterfacesRepository.IReporteService
{
    private readonly MedicalOfficeSqlLocalDB _db;

    public ExpressPosRepository(MedicalOfficeSqlLocalDB db)
    {
        _db = db;
    }

    // Implementación de IProductoService
    public async Task AgregarProductoAsync(string nombre, double precio, int stock)
    {
        var producto = new Productos { Nombre = nombre, Precio = precio, Stock = stock };
        await _db.AgregarProducto(producto).ConfigureAwait(false);
    }

    public async Task ActualizarProductoAsync(int productoId, string nombre, double precio, int stock)
    {
        var producto = new Productos { ProductoID = productoId, Nombre = nombre, Precio = precio, Stock = stock };
        await _db.ActualizarProducto(producto).ConfigureAwait(false);
    }

    public async Task EliminarProductoAsync(int productoId)
    {
        var producto = new Productos { ProductoID = productoId };
        await _db.EliminarProducto(producto).ConfigureAwait(false);
    }

    public async Task<Productos> ObtenerProductoPorIdAsync(int productoId)
        => await _db.ObtenerProductoPorId(productoId).ConfigureAwait(false);

    public async Task<IEnumerable<Productos>> ObtenerTodosLosProductosAsync()
        => await _db.ObtenerTodosLosProductos().ConfigureAwait(false);

    public async Task ActualizarStockAsync(int productoId, int nuevoStock)
    {
        var producto = new Productos { ProductoID = productoId, Stock = nuevoStock };
        await _db.ActualizarStock(producto).ConfigureAwait(false);
    }

    public async Task<IEnumerable<Productos>> ObtenerProductosConBajoStockAsync(int limiteStock)
        => await _db.ObtenerProductosConBajoStock(limiteStock).ConfigureAwait(false);

    // Implementación de IVentaService
    public async Task<int> RegistrarVentaAsync(DateTime fechaHora, double total, IEnumerable<(int ProductoID, int Cantidad)> productos)
    {
        var venta = new Ventas { FechaHora = fechaHora, Total = (decimal)total };
        var detalles = productos.Select(p => new DetalleVentas
        {
            ProductoID = p.ProductoID,
            Cantidad = p.Cantidad,
            Subtotal = p.Cantidad * productos.First(x => x.ProductoID == p.ProductoID).Cantidad
        });
        return await _db.RegistrarVenta(venta, detalles).ConfigureAwait(false);
    }

    public async Task EliminarVentaAsync(int ventaId)
    {
        var venta = new Ventas { VentaID = ventaId };
        await _db.EliminarVenta(venta).ConfigureAwait(false);
    }

    public async Task<Ventas> ObtenerVentaPorIdAsync(int ventaId)
        => await _db.ObtenerVentaPorId(ventaId).ConfigureAwait(false);

    public async Task<IEnumerable<Ventas>> ObtenerVentasAsync()
        => await _db.ObtenerVentas().ConfigureAwait(false);

    public async Task<IEnumerable<Ventas>> ObtenerVentasPorRangoAsync(DateTime fechaInicio, DateTime fechaFin)
        => await _db.ObtenerVentasPorRango(fechaInicio, fechaFin).ConfigureAwait(false);

    public async Task<IEnumerable<DetalleVentas>> ObtenerDetalleDeVentaAsync(int ventaId)
        => await _db.ObtenerDetalleDeVenta(ventaId).ConfigureAwait(false);

    // Implementación de ICorteService
    public async Task RegistrarCorteAsync(double totalVendido, int totalVentas)
    {
        var corte = new Cortes { FechaHora = DateTime.Now, TotalVendido = totalVendido, TotalVentas = totalVentas };
        await _db.RegistrarCorte(corte).ConfigureAwait(false);
    }

    public async Task EliminarCorteAsync(int corteId)
    {
        var corte = new Cortes { CorteID = corteId };
        await _db.EliminarCorte(corte).ConfigureAwait(false);
    }

    public async Task<Cortes> ObtenerCortePorIdAsync(int corteId)
        => await _db.ObtenerCortePorId(corteId).ConfigureAwait(false);

    public async Task<IEnumerable<Cortes>> ObtenerCortesAsync()
        => await _db.ObtenerCortes().ConfigureAwait(false);

    public async Task<IEnumerable<Cortes>> ObtenerCortesPorRangoAsync(DateTime fechaInicio, DateTime fechaFin)
        => await _db.ObtenerCortesPorRango(fechaInicio, fechaFin).ConfigureAwait(false);

    // Implementación de IReporteService
    public async Task<IEnumerable<VentasPorDia>> ObtenerVentasPorDiaAsync(DateTime fechaInicio, DateTime fechaFin)
        => await _db.ObtenerVentasPorDia(fechaInicio, fechaFin).ConfigureAwait(false);

    public async Task<IEnumerable<Cortes>> ObtenerResumenDeCortesPorDiaAsync(DateTime fechaInicio, DateTime fechaFin)
        => await _db.ObtenerResumenDeCortesPorDia(fechaInicio, fechaFin).ConfigureAwait(false);
}
