using System;
using System.Reflection;
using SimpleDDD.Query.Exceptions;

namespace SimpleDDD.Query
{
    public abstract class Fetchable
    {
        private readonly string container;
        
        protected Fetchable(string container)
        {
            this.container = container;
            this.Validate();
        }

        private void Validate()
        {
            if(string.IsNullOrEmpty(this.container))
            {
                throw new FetchableContainerEmptyException();
            }
        }

        public static T SelectFrom<T>() where T : Fetchable
        {
            try
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
            catch (TargetInvocationException tie)
            {
                if(tie.InnerException != null)
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

    //todo make serializable
}