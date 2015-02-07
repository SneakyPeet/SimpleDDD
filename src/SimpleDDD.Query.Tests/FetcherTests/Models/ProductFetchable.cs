namespace SimpleDDD.Query.Tests.FetcherTests.Models
{
    public class ProductFetchable : Fetchable<ProductFetchable, Product>
    {
        public ProductFetchable()
            : base("Products")
        {

        }
    }
}