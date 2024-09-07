namespace Medical.Office.Infra.DataSources
{
    /// <summary>
    /// #4
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConfigurationSqlDbConnection<T> : DapperSqlDbConnection
    {
        public ConfigurationSqlDbConnection(ConfigurationSqlDbConnectionFactory<T> factory)
            : base(factory)
        { }
    }
}
