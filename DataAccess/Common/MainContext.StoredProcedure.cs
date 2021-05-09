using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccess.Common
{
    /// <summary>
    /// MainContext
    /// </summary>
    public partial class MainContext
    {
        public virtual int ExecuteQuery(string sQuery, params SqlParameter[] sqlParameter)
        {
            return Database.ExecuteSqlRaw(sQuery, sqlParameter);
        }
        public virtual Task<int> ExecuteQueryAsync(string sQuery, params SqlParameter[] sqlParameter)
        {
            return Database.ExecuteSqlRawAsync(sQuery, sqlParameter);
        }
        public string ConnectionString()
        {
            return Database.GetDbConnection().ConnectionString;
        }
    }
}
