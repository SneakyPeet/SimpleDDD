using NUnit.Framework;
using SimpleDDD.Query.Exceptions;

namespace SimpleDDD.Query.Tests
{
    [TestFixture]
    public class FetchableTests
    {
        [Test]
        public void GivenFetchable_QueryShouldNotBe_Null()
        {
            var fetchable = Fetchable.SelectFrom<TestTable>();

            Assert.IsNotNull(fetchable);
        }

        [Test]
        public void GivenFetchable_QueryShouldBe_CorrectType()
        {
            var fetchable = Fetchable.SelectFrom<TestTable>();

            Assert.AreEqual(typeof(TestTable), fetchable.GetType());
        }

        [Test]
        [ExpectedException(typeof(FetchableContainerEmptyException))]
        public void GivenFetchable_WithNullOrEmptyContainer_ThrowException()
        {
            Fetchable.SelectFrom<EmptyContainerTestTable>();
        }

        //[Test]
        //public void GivenFetchable_QueryShouldBe_SelectStarFrom()
        //{
        //    var fetchable = Fetchable.SelectFrom<TestTable>();

        //    Assert.AreEqual("Select * From TestTable", fetchable.Query);
        //}

    }

    
}
