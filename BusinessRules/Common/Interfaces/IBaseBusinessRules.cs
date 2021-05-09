using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessRules.Common.Interfaces
{
    /// <summary>
    /// IBaseBusinessRules
    /// </summary>
    /// <typeparam name="T">BaseBusinessRules</typeparam>
    public interface IBaseBusinessRules<T>
         where T : class, new()
    {
        string NameClassReference { get; }
        bool? Delete(Expression<Func<T, bool>> expression);
        Task<bool?> DeleteAsync(Expression<Func<T, bool>> expression);
    }
}
