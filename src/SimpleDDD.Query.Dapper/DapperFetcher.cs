using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace SimpleDDD.Query.Dapper
{
    public class DapperFetcher : IFetcher
    {
        //todo move to config
        private const string connectionString = "Data Source=.;Initial Catalog=SimpleDDD;Integrated Security=True";

        public IEnumerable<T> FetchMeAll<T>(T fetchable) where T : Fetchable
        {
            using (var connection = new SqlConnection(connectionString))
            {
                //connection.Open();
                //var products = connection.Query<T>("Select * from " + fetchable.Container);
                //connection.Close();
                //return products;
                throw new NotImplementedException();
            }
        }
    }
}