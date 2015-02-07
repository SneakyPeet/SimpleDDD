using System;
using System.Reflection;
using SimpleDDD.Query.Exceptions;

namespace SimpleDDD.Query
{
    public class Select
    {
        public static T From<T>() where T : Fetchable
        {
            try
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
            catch (TargetInvocationException tie)
            {
                if (tie.InnerException != null)
                {
                    if (tie.InnerException is FetchableContainerEmptyException)
                    {
                        throw new FetchableContainerEmptyException();
                    }
                }
                throw;
            }
        }
    }
}