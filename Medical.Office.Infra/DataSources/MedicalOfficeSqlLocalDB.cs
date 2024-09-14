namespace Medical.Office.Infra.DataSources
{
    /// <summary>
    /// 
    /// </summary>
    public class MedicalOfficeSqlLocalDB
    {
        private readonly ConfigurationSqlDbConnection<MedicalOfficeSqlLocalDB> _con;

        public MedicalOfficeSqlLocalDB(ConfigurationSqlDbConnection<MedicalOfficeSqlLocalDB> con)
        {
            _con=con;   
        }


    }
}
