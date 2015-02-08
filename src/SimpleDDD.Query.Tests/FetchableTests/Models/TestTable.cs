namespace SimpleDDD.Query.Tests.FetchableTests.Models
{
    public class TestTable : Fetchable<TestTable, ReturnType>
    {
        public TestTable()
            : base("TestTable")
        {
            
        }
    }

    public class ReturnType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Check { get; set; }
    }

    public class EmptyContainerTestTable : Fetchable<EmptyContainerTestTable, ReturnType>
    {
        public EmptyContainerTestTable() : base(null)
        {
            
        }
    }
}