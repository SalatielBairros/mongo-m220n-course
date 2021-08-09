namespace M220N.Console.Settings
{
    public class MongoConnection
    {
        public MongoConnection(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }
    }
}