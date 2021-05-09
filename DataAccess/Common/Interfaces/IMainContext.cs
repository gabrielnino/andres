using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Common.Interfaces
{
    /// <summary>
    /// IMainContext
    /// </summary>
    public interface IMainContext
    {
        int NumberOfRecordPage { set; get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        IModel Model { get; }
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int ExecuteQuery(string sQuery, params SqlParameter[] sqlParameter);
        Task<int> ExecuteQueryAsync(string sQuery, params SqlParameter[] sqlParameter);
    }
}
