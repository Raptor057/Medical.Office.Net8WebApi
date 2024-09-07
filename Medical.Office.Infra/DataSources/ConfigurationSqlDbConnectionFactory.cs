using Microsoft.Extensions.Configuration;

namespace Medical.Office.Infra.DataSources
{
    /// <summary>
    /// #3
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConfigurationSqlDbConnectionFactory<T> : SqlDbConnectionFactory
    {
        public ConfigurationSqlDbConnectionFactory(IConfigurationRoot config)
            : base(config.GetConnectionString(typeof(T).Name) ?? throw new InvalidOperationException($"Cadena de conexion {typeof(T).Name} no encontrada."))
        { }
    }
}
