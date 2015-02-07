namespace SimpleDDD.Query.Tests
{
    public class TestTable : Fetchable
    {
        public TestTable() : base("TestTable")
        {
            
        }
    }

    public class EmptyContainerTestTable : Fetchable
    {
        public EmptyContainerTestTable() : base(null)
        {
            
        }
    }
}