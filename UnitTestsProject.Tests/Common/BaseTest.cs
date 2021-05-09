using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Test.Common
{
    public abstract class BaseTest<INegocio>
           where INegocio : class
    {
        /// <summary>
        /// Metodo Transversal para cargar valores a los objetos de la entidad
        /// </summary>
        /// <typeparam name="TValue">Tipo de dato</typeparam>
        /// <param name="value">Valor</param>
        /// <param name="name">Nombre de la propiedad de la entidad</param>
        /// <returns></returns>
        protected TValue GetValue<TValue>(string value, string name)
        {
            name = AddBehaviorObjects(name);

            return ((TValue)Convert.ChangeType(
                ((typeof(TValue) == typeof(string)) ? string.Concat(name, " ", value) : value),
                typeof(TValue)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceList"></param>
        /// <returns></returns>
        protected static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class, new()
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>() { CallBase = true };
            dbSet.As<IDbAsyncEnumerable<T>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<T>(queryable.GetEnumerator()));

            dbSet.As<IQueryable<T>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<T>(queryable.Provider));

            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            dbSet.As<IQueryable<T>>()
                .Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<T>(queryable.Provider));

            dbSet.As<System.Data.Entity.IDbSet<T>>().Setup(m => m.Create()).Returns(new T());
            dbSet.As<System.Data.Entity.IDbSet<T>>().Setup(m => m.Add(It.IsAny<T>())).Returns<T>(i => { sourceList.Add(i); return i; });
            dbSet.Setup(m => m.AddRange(It.IsAny<IEnumerable<T>>()));
            dbSet.As<System.Data.Entity.IDbSet<T>>().Setup(m => m.Remove(It.IsAny<T>())).Returns<T>(i => { sourceList.Remove(i); return i; });
            dbSet.Setup(m => m.RemoveRange(It.IsAny<IEnumerable<T>>()));
            dbSet.Setup(x => x.Add(It.IsAny<T>())).Returns<T>(i => { sourceList.Add(i); return null; });
            dbSet.Setup(x => x.Remove(It.IsAny<T>())).Returns<T>(i => { sourceList.Remove(i); return null; });

            return dbSet.Object;
        }

        /// <summary>
        /// Metodo virtualizado para implementar en las entidades mock de objetos necesario para las pruebas unitarias
        /// </summary>
        protected virtual void AddAdaptadorMock() { }

        /// <summary>
        /// Metodo virtualizado para realizar customizaciones de valores de objetos transversales de la entidad
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected virtual string AddBehaviorObjects(string name) { return name; }
    }
    /// <summary>
    /// TestDbAsyncQueryProvider
    /// </summary>
    /// <typeparam name="TEntity">TEntity</typeparam>
    internal class TestDbAsyncQueryProvider<TEntity> : IDbAsyncQueryProvider
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IQueryProvider _inner;
        /// <summary>
        /// TestDbAsyncQueryProvider
        /// </summary>
        /// <param name="inner">inner</param>
        internal TestDbAsyncQueryProvider(IQueryProvider inner) { _inner = inner; }
        /// <summary>
        /// CreateQuery
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>IQueryable</returns>
        public IQueryable CreateQuery(Expression expression) { return new TestDbAsyncEnumerable<TEntity>(expression); }
        /// <summary>
        ///  CreateQuery
        /// </summary>
        /// <typeparam name="TElement">TElement</typeparam>
        /// <param name="expression">expression</param>
        /// <returns></returns>
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression) { return new TestDbAsyncEnumerable<TElement>(expression); }
        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>IS </returns>
        public object Execute(Expression expression) { return _inner.Execute(expression); }
        /// <summary>
        /// Execute
        /// </summary>
        /// <typeparam name="TResult">TResult</typeparam>
        /// <param name="expression">expression</param>
        /// <returns>Is </returns>
        public TResult Execute<TResult>(Expression expression) { return _inner.Execute<TResult>(expression); }
        /// <summary>
        /// ExecuteAsync
        /// </summary>
        /// <param name="expression">expression</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken) { return Task.FromResult(Execute(expression)); }
        /// <summary>
        /// ExecuteAsync
        /// </summary>
        /// <typeparam name="TResult">TResult</typeparam>
        /// <param name="expression">expression</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>Result</returns>
        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken) { return Task.FromResult(Execute<TResult>(expression)); }
    }
    /// <summary>
    /// TestDbAsyncEnumerable
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    internal class TestDbAsyncEnumerable<T> : EnumerableQuery<T>, IDbAsyncEnumerable<T>
    {
        public TestDbAsyncEnumerable(IEnumerable<T> enumerable) : base(enumerable) { }
        public TestDbAsyncEnumerable(Expression expression) : base(expression) { }
        public IDbAsyncEnumerator<T> GetAsyncEnumerator() { return new TestDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator()); }
        IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator() { return GetAsyncEnumerator(); }
        public IQueryProvider Provider { get { return new TestDbAsyncQueryProvider<T>(this); } }
    }
    /// <summary>
    /// TestDbAsyncEnumerator
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    internal class TestDbAsyncEnumerator<T> : IDbAsyncEnumerator<T>
    {
        /// <summary>
        /// IEnumerator
        /// </summary>
        private readonly IEnumerator<T> _inner;
        /// <summary>
        /// TestDbAsyncEnumerator
        /// </summary>
        /// <param name="inner">IEnumerator</param>
        public TestDbAsyncEnumerator(IEnumerator<T> inner) { _inner = inner; }
        public void Dispose() { _inner.Dispose(); }
        public Task<bool> MoveNextAsync(CancellationToken cancellationToken) { return Task.FromResult(_inner.MoveNext()); }
        public T Current { get { return _inner.Current; } }
        object IDbAsyncEnumerator.Current { get { return Current; } }
    }
    /// <summary>
    /// TestAsyncQueryProvider
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    internal class TestAsyncQueryProvider<TEntity> : IDbAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        internal TestAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new TestAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new TestAsyncEnumerable<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute<TResult>(expression));
        }

        public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute(expression));
        }
    }
    /// <summary>
    /// TestAsyncEnumerable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class TestAsyncEnumerable<T> : EnumerableQuery<T>, IQueryable<T>
    {
        /// <summary>
        /// TestAsyncEnumerable
        /// </summary>
        /// <param name="enumerable">enumerable</param>
        public TestAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        { }
        /// <summary>
        /// TestAsyncEnumerable
        /// </summary>
        /// <param name="expression">expression</param>
        public TestAsyncEnumerable(Expression expression)
            : base(expression)
        { }
        /// <summary>
        /// IQueryProvider
        /// </summary>
        IQueryProvider IQueryable.Provider
        {
            get { return new TestAsyncQueryProvider<T>(this); }
        }
    }
}
