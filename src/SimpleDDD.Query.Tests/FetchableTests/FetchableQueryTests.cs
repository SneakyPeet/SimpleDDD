using NUnit.Framework;
using SimpleDDD.Query.Tests.FetchableTests.Models;

namespace SimpleDDD.Query.Tests.FetchableTests
{
    [TestFixture]
    public class FetchableQueryTests
    {
        [Test]
        public void GivenFetchable_QueryShouldBe_SelectStarFrom()
        {
            var fetchable = Select.From<TestTable>();

            Assert.AreEqual("Select * From TestTable", fetchable.Query);
        }
    }

    
}
