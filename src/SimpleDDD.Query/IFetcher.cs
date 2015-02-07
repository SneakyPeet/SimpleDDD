using System.Collections.Generic;

namespace SimpleDDD.Query
{
    public interface IFetcher
    {
        IEnumerable<T> FetchMeAll<T>(T fetchable) where T : Fetchable;
    }
}