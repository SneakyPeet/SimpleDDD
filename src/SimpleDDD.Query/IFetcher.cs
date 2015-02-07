using System.Collections.Generic;

namespace SimpleDDD.Query
{
    public interface IFetcher
    {
        IEnumerable<TResult> All<TResult>(Fetchable fetchable);
    }
}