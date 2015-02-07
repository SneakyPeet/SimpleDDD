using SimpleDDD.Query.Exceptions;

namespace SimpleDDD.Query
{
    public abstract class Fetchable<T, TResult> : Fetchable where T : Fetchable<T, TResult>
    {
        protected Fetchable(string container) : base(container) { }
    }

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
            if (string.IsNullOrEmpty(this.container))
            {
                throw new FetchableContainerEmptyException();
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