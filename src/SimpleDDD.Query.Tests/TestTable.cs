namespace SimpleDDD.Query.Tests
{
    public class TestTable : Fetchable
    {
        public TestTable()
            : base("TestTable", typeof(ReturnType))
        {
            
        }
    }

    public class ReturnType
    {
        
    }

    public class EmptyContainerTestTable : Fetchable
    {
        public EmptyContainerTestTable() : base(null, null)
        {
            
        }
    }

    public class NullTypeTestTable : Fetchable
    {
        public NullTypeTestTable()
            : base("TestTable", null)
        {

        }
    }
}