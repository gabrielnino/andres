using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Common.Interfaces
{
    /// <summary>
    /// IRepositoryBase
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T> where T : class, new()
    {
        IMainContext RepositoryContext { get; }
        ICollection<T> ToList();
        T Search(Expression<Func<T, bool>> expression);
        T Search(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        int? Create(T objCreate);
        int? Create(IEnumerable<T> objCreate);
        bool? Edit(T objEdit);
        bool? Edit(ICollection<T> objEdit);
        bool? Delete(T objDelete);
        int Count(Expression<Func<T, bool>> expression);
        Task<List<T>> ToListAsync();
        Task<List<T>> ToListAsync(Expression<Func<T, bool>> expression);
        bool? DeleteRange(Expression<Func<T, bool>> expression);
        Task<T> SearchAsync(Expression<Func<T, bool>> expression);
        Task<T> SearchAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        Task<int?> CreateAsync(T objCreate);
        Task<int?> CreateAsync(IEnumerable<T> objCreate);
        Task<bool?> EditAsync(T objEdit);
        Task<bool?> EditAsync(ICollection<T> objEdit);
        Task<bool?> DeleteAsync(T objDelete);
        Task<bool?> DeleteRangeAsync(Expression<Func<T, bool>> expression);
    }
}
