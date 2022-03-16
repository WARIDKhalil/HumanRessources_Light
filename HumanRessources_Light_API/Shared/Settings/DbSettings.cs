namespace HumanRessources_Light_API.DbConfiguration
{
    /// <summary>
    ///  Shared properties to establish a connection with a database
    /// </summary>
    public class DbSettings
    {
        /// <summary>
        ///     Name of database
        /// </summary>
        public string DatabaseName { get; set; }
        /// <summary>
        ///     URL to establish the connection with the database server
        /// </summary>
        public string ConnectionString { get; set; }

    }
}
