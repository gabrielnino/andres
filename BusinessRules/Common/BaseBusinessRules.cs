using BusinessRules.Common.Interfaces;
using DataAccess.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using Utilities.CustomException;
using Utilities.ExtensionMethods;

namespace BusinessRules.Common
{
    /// <summary>
    /// BaseBusinessRules
    /// </summary>
    /// <typeparam name="T">Generic</typeparam>
    /// <typeparam name="TImplementacion">Generic Implementation</typeparam>
    public abstract class BaseBusinessRules<T, TImplementacion> :  IRepositoryBase<T>, IBaseBusinessRules<T>
      where T : class, new()
      where TImplementacion : IRepositoryBase<T>
    {
        /// <summary>
        /// /DaoNegocio
        /// </summary>
        protected readonly TImplementacion DaoNegocio;
        public IMainContext RepositoryContext => DaoNegocio.RepositoryContext;
        public string NameClassReference { get; }
        /// <summary>
        /// TImplementacion
        /// </summary>
        /// <param name="daoNegocio"></param>
        protected BaseBusinessRules(TImplementacion daoNegocio)
        {
            DaoNegocio = daoNegocio;

            if (DaoNegocio.RepositoryContext.NumberOfRecordPage <= 0)
            {
                DaoNegocio.RepositoryContext.NumberOfRecordPage = 20;
            }

            NameClassReference = daoNegocio?.GetType()?.Name ?? string.Empty;
        }
        /// <summary>
        /// ExceptionBehavior
        /// </summary>
        /// <typeparam name="TReturn">TReturn</typeparam>
        /// <param name="fnAccion"></param>
        /// <returns>Is Action</returns>
        protected static TReturn ExceptionBehavior<TReturn>(Func<TReturn> fnAccion)
        {
            TReturn returnBehavior;

            try
            {
                returnBehavior = fnAccion();
            }
            catch (Exception)
            {
                returnBehavior = default;
            }
            return returnBehavior;
        }
        /// <summary>
        /// Count
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>Count entity</returns>
        public int Count(Expression<Func<T, bool>> expression)
        {
            return ExceptionBehavior(() => DaoNegocio.Count(expression));
        }
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="objCreate">Id Entity</param>
        /// <returns>Id Entity</returns>
        public int? Create(T objCreate)
        {
            int? objReturn = null;
            if (objCreate.IsNotNull())
            {
                objReturn = ExceptionBehavior(() =>
                {
                    ValidationsToCreate(objCreate);

                    using var tran = new TransactionScope();
                    int? objReturn = DaoNegocio.Create(objCreate);
                    tran.Complete();
                    return objReturn;
                });
            }

            return objReturn;
        }
        /// <summary>
        /// Validations To Create
        /// </summary>
        /// <param name="entity">Entity</param>
        protected virtual void ValidationsToCreate(T entity) { entity.TrimAll(); }
        public int? Create(IEnumerable<T> objCreate)
        {
            return ExceptionBehavior(() => DaoNegocio.Create(objCreate));
        }
        /// <summary>
        /// CreateAsync
        /// </summary>
        /// <param name="objCreate">Entity</param>
        /// <returns>Id Create</returns>
        public async Task<int?> CreateAsync(T objCreate)
        {
            int? objReturn = null;
            if (objCreate.IsNotNull())
            {
                objReturn = await ExceptionBehaviorAsync(async () =>
                {
                    ValidationsToCreate(objCreate);

                    using var tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
                    var objReturn = await DaoNegocio.CreateAsync(objCreate).ConfigureAwait(false);
                    tran.Complete();
                    return objReturn;
                }).ConfigureAwait(false);
            }

            return objReturn;
        }
        /// <summary>
        /// ExceptionBehaviorAsync
        /// </summary>
        /// <typeparam name="TReturn">TReturn</typeparam>
        /// <param name="fnAccion">fnAccion</param>
        /// <returns>TReturn</returns>
        protected static async Task<TReturn> ExceptionBehaviorAsync<TReturn>(Func<Task<TReturn>> fnAccion)
        {
            TReturn returnBehavior;

            try
            {
                returnBehavior = await fnAccion().ConfigureAwait(false);
            }
            catch (DbUpdateException ex)
            {
                var message = "It is impossible to create a record because the step and the next step are the same. {0}";
                var exception = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                message = string.Format(message, exception);
                throw new CustomException(TypeCustomException.Validation, message);
            }
            catch (Exception ex)
            {
                var i = ex;
                returnBehavior = default;
            }

            return returnBehavior;
        }


        /// <summary>
        /// CreateAsync
        /// </summary>
        /// <param name="objCreate">objCreate</param>
        /// <returns>Id Entity created</returns>
        public async Task<int?> CreateAsync(IEnumerable<T> objCreate)
        {
            return await ExceptionBehaviorAsync(() => DaoNegocio.CreateAsync(objCreate)).ConfigureAwait(false);
        }
        protected virtual void ValidationsToDelete(T entity) { }
        public bool? Delete(T objDelete)
        {
            bool? objReturn = null;
            if (objDelete.IsNotNull())
            {
                objReturn = ExceptionBehavior(() =>
                {
                    ValidationsToDelete(objDelete);
                    using var tran = new TransactionScope();
                    var objReturn = DaoNegocio.Delete(objDelete);
                    tran.Complete();
                    return objReturn;
                });
            }

            return objReturn;
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>Is deleted</returns>
        public bool? Delete(Expression<Func<T, bool>> expression)
        {
            return ExceptionBehavior(() =>
            {
                var objDelete = Search(expression);
                if (objDelete.IsNotNull())
                {
                    ValidationsToDelete(objDelete);

                    using var tran = new TransactionScope();
                    var objReturn = DaoNegocio.Delete(objDelete);

                    tran.Complete();
                    return objReturn;
                }
                else
                {
                    throw new Exception("It not found");
                }
            });
        }
        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="objDelete">objDelete</param>
        /// <returns>Is Deleted</returns>
        public async Task<bool?> DeleteAsync(T objDelete)
        {
            bool? objReturn = null;
            if (objDelete.IsNotNull())
            {
                objReturn = await ExceptionBehaviorAsync(async () =>
                {
                    ValidationsToDelete(objDelete);
                    using var tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
                    var objReturn = await DaoNegocio.DeleteAsync(objDelete).ConfigureAwait(false);
                    tran.Complete();
                    return objReturn;
                }).ConfigureAwait(false);
            }

            return objReturn;
        }
        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>Is Deleted</returns>
        public async Task<bool?> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            return await ExceptionBehaviorAsync(async () =>
            {
                var objDelete = Search(expression);
                if (!objDelete.IsNotNull())
                {
                    throw new Exception("It not found");
                }
                else
                {
                    ValidationsToDelete(objDelete);

                    using var tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
                    var objReturn = await DaoNegocio.DeleteAsync(objDelete).ConfigureAwait(false);

                    tran.Complete();
                    return objReturn;
                }
            }).ConfigureAwait(false);
        }
        /// <summary>
        /// Delete Range
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>Is Deleted</returns>
        public bool? DeleteRange(Expression<Func<T, bool>> expression)
        {
            if (expression.IsNotNull())
            {
                var objDelete = this.RepositoryContext.Set<T>().Where(expression).ToList();
                if (objDelete.IsNotNull() && !objDelete.Count.Equals(0))
                {
                    this.RepositoryContext.Set<T>().RemoveRange(objDelete);
                    return this.RepositoryContext.SaveChanges() != 0;
                }

                return false;
            }

            return null;
        }
        /// <summary>
        /// Delete Range Async
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>Is Valid</returns>
        public async Task<bool?> DeleteRangeAsync(Expression<Func<T, bool>> expression)
        {
            return await ExceptionBehaviorAsync(() => DaoNegocio.DeleteRangeAsync(expression)).ConfigureAwait(false);
        }
        /// <summary>
        /// Validations To Edit
        /// </summary>
        /// <param name="entity">entity</param>
        protected virtual void ValidationsToEdit(T entity) { entity.TrimAll(); }
        public bool? Edit(T objEdit)
        {
            bool? objReturn = null;
            if (objEdit.IsNotNull())
            {
                objReturn = ExceptionBehavior(() =>
                {
                    ValidationsToEdit(objEdit);
                    using var tran = new TransactionScope();
                    var objReturn = DaoNegocio.Edit(objEdit);

                    tran.Complete();
                    return objReturn;
                });
            }

            return objReturn;
        }
        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="objEdit">obj to edit</param>
        /// <returns>Is Edit</returns>
        public bool? Edit(ICollection<T> objEdit)
        {
            return ExceptionBehavior(() => DaoNegocio.Edit(objEdit));
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>Entity</returns>
        public T Search(Expression<Func<T, bool>> expression)
        {
            return ExceptionBehavior(() => DaoNegocio.Search(expression));
        }
        /// <summary>
        /// Search
        /// </summary>
        /// <param name="expression">expression</param>
        /// <param name="includes">includes</param>
        /// <returns>Entity</returns>
        public T Search(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            return ExceptionBehavior(() => DaoNegocio.Search(expression, includes));
        }

        public async Task<T> SearchAsync(Expression<Func<T, bool>> expression)
        {
            return await ExceptionBehaviorAsync(async () => await DaoNegocio.SearchAsync(expression).ConfigureAwait(false)).ConfigureAwait(false);
        }
        /// <summary>
        /// SearchAsync
        /// </summary>
        /// <param name="expression">expression</param>
        /// <param name="includes">includes</param>
        /// <returns></returns>
        public async Task<T> SearchAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            return await ExceptionBehaviorAsync(async () => await DaoNegocio.SearchAsync(expression, includes).ConfigureAwait(false)).ConfigureAwait(false);
        }
        /// <summary>
        /// List
        /// </summary>
        /// <returns>Get List</returns>
        public ICollection<T> ToList()
        {
            return DaoNegocio.ToList();
        }

        public async Task<List<T>> ToListAsync()
        {
            return await ExceptionBehaviorAsync(() => DaoNegocio.ToListAsync());
        }
        /// <summary>
        /// Get List Async
        /// </summary>
        /// <param name="expression">filter</param>
        /// <returns>List</returns>
        public async Task<List<T>> ToListAsync(Expression<Func<T, bool>> expression)
        {
            return await ExceptionBehaviorAsync(() => DaoNegocio.ToListAsync(expression));
        }
        /// <summary>
        /// Edit Async by Collection
        /// </summary>
        /// <param name="objEdit">Is Edit</param>
        /// <returns></returns>
        public async Task<bool?> EditAsync(ICollection<T> objEdit)
        {
            return await ExceptionBehaviorAsync(() => DaoNegocio.EditAsync(objEdit)).ConfigureAwait(false);
        }
        /// <summary>
        /// Edit Async
        /// </summary>
        /// <param name="objEdit"></param>
        /// <returns>Is Edit</returns>
        public async Task<bool?> EditAsync(T objEdit)
        {
            bool? objReturn = null;
            if (objEdit.IsNotNull())
            {
                objReturn = await ExceptionBehaviorAsync(async () =>
                {
                    ValidationsToEdit(objEdit);
                    using var tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
                    var objReturn = await DaoNegocio.EditAsync(objEdit).ConfigureAwait(false);
                    tran.Complete();
                    return objReturn;
                }).ConfigureAwait(false);
            }
            return objReturn;
        }
    }
}
