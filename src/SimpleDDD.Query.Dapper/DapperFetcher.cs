using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace SimpleDDD.Query.Dapper
{
    public class DapperFetcher : IFetcher
    {
        //todo move to config
        private readonly string connectionString;

        public DapperFetcher(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<T> All<T>(Fetchable fetchable)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var results = connection.Query<T>(fetchable.Query);
                return results;
            }
        }
    }
}