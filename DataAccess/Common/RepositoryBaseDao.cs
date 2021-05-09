using DataAccess.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Utilities.ExtensionMethods;

namespace DataAccess.Common
{
    /// <summary>
    /// RepositoryBaseDao
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RepositoryBaseDao<T> : BaseRepositoryDao<T>, IRepositoryBase<T> 
        where T : class, new()
    {
        /// <summary>
        /// RepositoryBaseDao
        /// </summary>
        /// <param name="contexto"></param>
        protected RepositoryBaseDao(IMainContext contexto)
        {
            RepositoryContext = contexto;
        }
        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="objEdit">objEdit</param>
        /// <returns></returns>
        public bool? Edit(T objEdit)
        {
            bool? returnEdit = null;
            if (objEdit != null)
            {
                EntityStateModified(objEdit);

                returnEdit = ReturnRepositoryContextSaveChanges();
            }
            return returnEdit;
        }
        /// <summary>
        /// Entity State Modified
        /// </summary>
        /// <param name="objEdit">objEdit</param>
        private void EntityStateModified(T objEdit)
        {
            if (RepositoryContext.Entry(objEdit) != null)
            {
                RepositoryContext.Entry(objEdit).State = EntityState.Modified;
            }
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="objDelete">objDelete</param>
        /// <returns>Is Delete</returns>
        public bool? Delete(T objDelete)
        {
            bool? returnDelete = null;
            if (objDelete != null)
            {
                RepositoryContext.Set<T>().Remove(objDelete);
                returnDelete = ReturnRepositoryContextSaveChanges();
            }
            return returnDelete;
        }
        /// <summary>
        /// Return Repository Context Save Changes
        /// </summary>
        /// <returns>Is Found</returns>
        private bool ReturnRepositoryContextSaveChanges()
        {
            return RepositoryContextSaveChanges() != 0;
        }
        /// <summary>
        /// Repository Context Save Changes
        /// </summary>
        /// <returns>Is Save</returns>
        private int RepositoryContextSaveChanges()
        {
            return RepositoryContext.SaveChanges();
        }
        /// <summary>
        /// Return Repository Context Save Changes Async
        /// </summary>
        /// <returns>Is Save</returns>
        private async Task<bool> ReturnRepositoryContextSaveChangesAsync()
        {
            return await RepositoryContextSaveChangesAsync().ConfigureAwait(false) != 0;
        }
        /// <summary>
        /// Repository Context Save ChangesAsync
        /// </summary>
        /// <returns>Is Id</returns>
        private async Task<int> RepositoryContextSaveChangesAsync()
        {
            return (await RepositoryContext.SaveChangesAsync().ConfigureAwait(false));
        }
        /// <summary>
        /// Configure Parameter Of List
        /// </summary>
        /// <param name="IQuery">IQuery</param>
        /// <returns>Is Return</returns>
        protected IQueryable<T> ConfigureParameterOfList(IQueryable<T> IQuery)
        {
            return IQuery;
        }
        /// <summary>
        /// ToList
        /// </summary>
        /// <returns>T</returns>
        public ICollection<T> ToList()
        {
            return ConfigureParameterOfList(RepositoryContext.Set<T>()).ToList<T>();
        }
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="objCreate">objCreate</param>
        /// <returns>Is </returns>
        public int? Create(T objCreate)
        {
            int? returnCreate = null;
            if (objCreate != null)
            {
                RepositoryContext.Set<T>().Add(objCreate);
                returnCreate = RepositoryContextSaveChanges();
            }
            return returnCreate;
        }
        /// <summary>
        /// Search
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>Enitty</returns>
        public T Search(Expression<Func<T, bool>> expression)
        {
            T obj = null;
            if (expression.IsNotNull())
            {
                obj = RepositoryContext.Set<T>().Where(expression).FirstOrDefault();
                EntityStateDetached(obj);
            }
            return obj;
        }
        /// <summary>
        /// Search
        /// </summary>
        /// <param name="expression">expression</param>
        /// <param name="includes">includes</param>
        /// <returns>Entity Found</returns>
        public T Search(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            T obj = null;
            if (expression.IsNotNull())
            {
                obj = ConfigureIncludeSearch(RepositoryContext.Set<T>(), expression, includes).FirstOrDefault();
                EntityStateDetached(obj);
            }
            return obj;
        }
        /// <summary>
        /// EntityStateDetached
        /// </summary>
        /// <param name="obj">obj</param>
        private void EntityStateDetached(T obj)
        {
            if (obj.IsNotNull() && RepositoryContext.Entry(obj).IsNotNull())
            {
                RepositoryContext.Entry(obj).State = EntityState.Detached;
            }
        }
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="objCreate">objCreate</param>
        /// <returns>Id Create</returns>
        public int? Create(IEnumerable<T> objCreate)
        {
            int? returnCreate = null;
            if (objCreate.IsNotNull())
            {
                RepositoryContext.Set<T>().AddRange(objCreate);
                returnCreate = RepositoryContextSaveChanges();
            }
            return returnCreate;
        }
        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="objEdit">objEdit</param>
        /// <returns>Is Edit</returns>
        public bool? Edit(ICollection<T> objEdit)
        {
            bool? returnEdit = null;
            if (objEdit.IsNotNull())
            {
                foreach (var item in objEdit)
                {
                    EntityStateModified(item);
                }

                returnEdit = ReturnRepositoryContextSaveChanges();
            }
            return returnEdit;
        }
        /// <summary>
        /// Count
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>Count</returns>
        public int Count(Expression<Func<T, bool>> expression)
        {
            int returnCount = 0;
            if (expression.IsNotNull())
            {
                returnCount = RepositoryContext.Set<T>().Where(expression).Count();
            }
            return returnCount;
        }
        /// <summary>
        /// ToListAsync
        /// </summary>
        /// <returns>List</returns>
        public Task<List<T>> ToListAsync()
        {
            return this.RepositoryContext.Set<T>().ToListAsync<T>();
        }

        /// <summary>
        /// ToListAsync
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>List</returns>
        public Task<List<T>> ToListAsync(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).ToListAsync<T>();
        }
        /// <summary>
        /// DeleteRange
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>Is Bool</returns>
        public bool? DeleteRange(Expression<Func<T, bool>> expression)
        {
            if (expression.IsNotNull())
            {
                var objDelete = this.RepositoryContext.Set<T>().Where(expression).ToList();
                if (objDelete.IsNotNull())
                {
                    this.RepositoryContext.Set<T>().RemoveRange(objDelete);
                    return this.RepositoryContext.SaveChanges() != 0;
                }

                return false;
            }

            return null;
        }
        /// <summary>
        /// SearchAsync
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>Entity</returns>
        public async Task<T> SearchAsync(Expression<Func<T, bool>> expression)
        {
            T obj = null;
            if (expression.IsNotNull())
            {
                obj = await RepositoryContext.Set<T>().Where(expression).FirstOrDefaultAsync().ConfigureAwait(false);
            }
            return obj;
        }
        /// <summary>
        /// SearchAsync
        /// </summary>
        /// <param name="expression">expression</param>
        /// <param name="includes">includes</param>
        /// <returns>Entity</returns>
        public async Task<T> SearchAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            T obj = null;
            if (expression.IsNotNull())
            {
                obj = await ConfigureIncludeSearch(RepositoryContext.Set<T>(), expression, includes).FirstOrDefaultAsync().ConfigureAwait(false);
            }

            return obj;
        }
        /// <summary>
        /// CreateAsync
        /// </summary>
        /// <param name="objCreate">objCreate</param>
        /// <returns>Id</returns>
        public async Task<int?> CreateAsync(T objCreate)
        {
            int? returnCreate = null;
            if (objCreate.IsNotNull())
            {
                RepositoryContext.Set<T>().Add(objCreate);
                returnCreate = await RepositoryContextSaveChangesAsync().ConfigureAwait(false);
            }

            return returnCreate;
        }
        /// <summary>
        /// CreateAsync
        /// </summary>
        /// <param name="objCreate">objCreate</param>
        /// <returns>Id</returns>
        public async Task<int?> CreateAsync(IEnumerable<T> objCreate)
        {
            int? returnCreate = null;
            if (objCreate.IsNotNull())
            {
                RepositoryContext.Set<T>().AddRange(objCreate);
                returnCreate = await RepositoryContextSaveChangesAsync().ConfigureAwait(false);
            }

            return returnCreate;
        }
        /// <summary>
        /// EditAsync
        /// </summary>
        /// <param name="objEdit">objEdit</param>
        /// <returns>Is Edit</returns>
        public async Task<bool?> EditAsync(T objEdit)
        {
            bool? returnEdit = null;
            if (objEdit.IsNotNull())
            {
                EntityStateModified(objEdit);
                returnEdit = await ReturnRepositoryContextSaveChangesAsync().ConfigureAwait(false);
            }
            return returnEdit;
        }
        /// <summary>
        /// EditAsync
        /// </summary>
        /// <param name="objEdit">objEdit</param>
        /// <returns>Is Edit</returns>
        public async Task<bool?> EditAsync(ICollection<T> objEdit)
        {
            bool? returnEdit = null;
            if (objEdit.IsNotNull())
            {
                foreach (var item in objEdit)
                {
                    EntityStateModified(item);
                }
                returnEdit = await ReturnRepositoryContextSaveChangesAsync().ConfigureAwait(false);
            }

            return returnEdit;
        }
        /// <summary>
        /// Delete Async
        /// </summary>
        /// <param name="objDelete"></param>
        /// <returns>Is Delete</returns>
        public async Task<bool?> DeleteAsync(T objDelete)
        {
            bool? returnDelete = null;
            if (objDelete.IsNotNull())
            {
                RepositoryContext.Set<T>().Remove(objDelete);
                returnDelete = await ReturnRepositoryContextSaveChangesAsync().ConfigureAwait(false);
            }

            return returnDelete;
        }
        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>Is Delete</returns>
        public async Task<bool?> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            bool? returnDelete = null;
            if (expression.IsNotNull())
            {
                var objDelete = RepositoryContext.Set<T>().Where(expression).FirstOrDefault();
                if (objDelete.IsNotNull())
                {
                    RepositoryContext.Set<T>().Remove(objDelete);
                    returnDelete = await ReturnRepositoryContextSaveChangesAsync().ConfigureAwait(false);
                }
                else
                {
                    returnDelete = false;
                }
            }
            return returnDelete;
        }
        /// <summary>
        /// DeleteRangeAsync
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>Is Delete</returns>
        public async Task<bool?> DeleteRangeAsync(Expression<Func<T, bool>> expression)
        {
            bool? returnDelete = null;
            if (expression.IsNotNull())
            {
                var objDelete = RepositoryContext.Set<T>().Where(expression).ToList();
                if (objDelete.IsNotNull() && !objDelete.Count.Equals(0))
                {
                    RepositoryContext.Set<T>().RemoveRange(objDelete);
                    returnDelete = await ReturnRepositoryContextSaveChangesAsync().ConfigureAwait(false);
                }
                else
                {
                    returnDelete = false;
                }
            }
            return returnDelete;
        }
    }
}
