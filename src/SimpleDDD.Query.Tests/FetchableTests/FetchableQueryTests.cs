using System;
using NUnit.Framework;
using SimpleDDD.Query.Tests.FetchableTests.Models;
using SimpleDDD.Query.Language;

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
            Assert.IsFalse(fetchable.HasWhereClause);
        }

        [Test]
        public void GivenWhereFetchable_QueryShouldIncludeWhereClause()
        {
            var fetchable = Select.From<TestTable>().Where(x => x.Id == 1);

            Assert.AreEqual("Select * From TestTable Where Id = @Id", fetchable.Query);
            Assert.IsTrue(fetchable.HasWhereClause);
        }

        [Test]
        public void GivenWhereFetchable_QueryShouldBIncludeWhereClauseObject()
        {
            //var fetchable = Select.From<TestTable>().Where();

            //Assert.AreEqual("Select * From TestTable Where Id = @Id", fetchable.Query);
            //Assert.IsTrue(fetchable.HasWhereClause);
            //Assert.IsNotNull(fetchable.QueryParameter);
            throw new NotImplementedException("Test Return Param");
        }
    }

    
}
