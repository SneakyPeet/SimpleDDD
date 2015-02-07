using NUnit.Framework;
using SimpleDDD.Query.Exceptions;
using SimpleDDD.Query.Tests.FetchableTests.Models;

namespace SimpleDDD.Query.Tests.FetchableTests
{
    [TestFixture]
    public class FetchableConstructionTests
    {
        [Test]
        public void GivenFetchable_QueryShouldNotBe_Null()
        {
            var fetchable = Select.From<TestTable>();

            Assert.IsNotNull(fetchable);
        }

        [Test]
        public void GivenFetchable_QueryShouldBe_CorrectType()
        {
            var fetchable = Select.From<TestTable>();

            Assert.AreEqual(typeof(TestTable), fetchable.GetType());
        }

        [Test]
        [ExpectedException(typeof(FetchableContainerEmptyException))]
        public void GivenFetchable_WithNullOrEmptyContainer_ThrowException()
        {
            Select.From<EmptyContainerTestTable>();
        }
    }
}
