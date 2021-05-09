using DataAccess.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using Utilities.ExtensionMethods;

namespace DataAccess.Common
{
    /// <summary>
    /// BaseRepositoryDao
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseRepositoryDao<T>   where T : class, new()
    {
        public IMainContext RepositoryContext { get; protected set; }
        protected BaseRepositoryDao() { }
        protected static IQueryable<T> ConfigureIncludeSearch(IQueryable<T> IQuery, Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            if (includes.IsNotNull())
            {
                IQuery = includes.Aggregate(IQuery,(current, include) => current.Include(include));
            }
            IQuery = IQuery.Where(expression);
            return IQuery;
        }
    }
}
