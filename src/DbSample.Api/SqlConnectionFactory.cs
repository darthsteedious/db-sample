using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace DbSample.Api
{
    public static class SqlConnectionFactory
    {
        public static IDbConnection GetConnection(IConfiguration configuration)
        {
            var cs = configuration.GetConnectionString("ContactDB");
            return new SqliteConnection(configuration.GetConnectionString("ContactDb"));
        }
    }
}