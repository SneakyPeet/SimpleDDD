using System.Linq;
using NUnit.Framework;
using SimpleDDD.Query.Dapper;
using SimpleDDD.Query.Language;
using SimpleDDD.Query.Tests.FetcherTests.Models;

namespace SimpleDDD.Query.Tests.FetcherTests
{
    [TestFixture]
    public class FetcherTests
    {
        private IFetcher fetcher;

        [TestFixtureSetUp]
        public void SetupFixture()
        {
            this.fetcher = new DapperFetcher("Data Source=.;Initial Catalog=SimpleDDD;Integrated Security=True");
        }

        [Test]
        public void GivenSimleFetchable_FetchAllRows()
        {
            var fetchable = Select.From<ProductFetchable>();
            var products = this.fetcher.All<Product>(fetchable);

            Assert.AreEqual(4, products.Count());
        }
    }
}
