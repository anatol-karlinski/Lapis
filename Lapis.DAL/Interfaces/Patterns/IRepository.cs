using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lapis.DAL.Interfaces.Patterns
{
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Return all instances of type T.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Return all instances of type T asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Return all instances of type T that match the expression exp.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        IEnumerable<T> GetWhere(Expression<Func<T, bool>> exp);

        /// <summary>
        /// Return all instances of type T that match the expression exp asynchronously.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> exp);

        /// <summary>Returns the first element satisfying the condition.</summary>
        /// <param name="exp"></param><returns></returns>
        T GetFirst(Expression<Func<T, bool>> exp);

        /// <summary>Returns the first element satisfying the condition asynchronously.</summary>
        /// <param name="exp"></param><returns></returns>
        Task<T> GetFirstAsync(Expression<Func<T, bool>> exp);

        /// <summary>
        /// Delete entity.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Delete entity asynchronously.
        /// </summary>
        /// <param name="entity"></param>
        Task DeleteAsync(T entity);

        /// <summary>
        /// Add instance of type T.
        /// </summary>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// Add instance of type T asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Add instance of type T.
        /// </summary>
        /// <returns></returns>
        T Update(T entity);

        /// <summary>
        /// Add instance of type T.
        /// </summary>
        /// <returns></returns>
        Task<T> UpdateAsync(T entity);

    }
}
