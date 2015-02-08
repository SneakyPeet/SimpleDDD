using System;
using System.Linq.Expressions;
using System.Text;
using SimpleDDD.Query.Exceptions;

namespace SimpleDDD.Query
{
    public abstract class Fetchable<T, TResult> : Fetchable where T : Fetchable<T, TResult>
    {
        protected Fetchable(string container) : base(container) { }

        private Expression<Func<TResult, bool>> whereClause;

        /// <summary>
        /// Rather Use .Where()
        /// </summary>
        public void SetWhereClause(Expression<Func<TResult, bool>> where)
        {
            this.whereClause = where;
        }

        public override void WhereToString(StringBuilder query)
        {
            query.Append(" Where ");
            if (HasWhereClause)
            {
                var exp = whereClause.Body.ToString();
                var dot = exp.IndexOf(".");
                var eq = exp.IndexOf("==") - 1;
                var id = exp.Substring(dot + 1, eq - dot).Trim(' ');
                var value = exp.Substring(eq + 3).Trim(' ');
                query.Append(id + " = @" + id);

                
            }
        }

        public override bool HasWhereClause
        {
            get
            {
                return whereClause != null;
            }
        }


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
                var query = new StringBuilder();
                query.Append("Select * From " + container);
                this.WhereToString(query);
                return query.ToString();
            }
        }

        public abstract void WhereToString(StringBuilder query);

        public abstract bool HasWhereClause { get; }
    }
}