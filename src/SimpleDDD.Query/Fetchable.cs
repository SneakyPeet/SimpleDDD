using System;
using System.Reflection;
using SimpleDDD.Query.Exceptions;

namespace SimpleDDD.Query
{
    public abstract class Fetchable
    {
        private readonly string container;
        private readonly Type resultType;
        
        protected Fetchable(string container, Type resultType)
        {
            this.container = container;
            this.resultType = resultType;
            this.Validate();
        }

        private void Validate()
        {
            if(string.IsNullOrEmpty(this.container))
            {
                throw new FetchableContainerEmptyException();
            }
            if (this.resultType == null)
            {
                throw new FetchableResultTypeNullException();
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
                    var type = tie.InnerException.GetType();
                    if (type == typeof(FetchableContainerEmptyException))
                    {
                        throw new FetchableContainerEmptyException();
                    }
                    if (type == typeof(FetchableResultTypeNullException))
                    {
                        throw new FetchableResultTypeNullException();
                    }
                }
                throw;
            }
        }

        public string Query
        {
            get
            {
                return "Select * From " + container;
            }
        }
    }

    
}