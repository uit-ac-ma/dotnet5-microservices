using Ordering.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ordering.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : EntityBase
    {
        /// <summary>
        /// Get all Async
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAllAsync();

        /// <summary>
        /// Get Async
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Get Async
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="Func<IQueryable<T>"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeString"></param>
        /// <param name="disableTracking"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        string includeString = null,
                                        bool disableTracking = true);

        /// <summary>
        /// Get Aync
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="Func<IQueryable<T>"></param>
        /// <param name="orderBy"></param>
        /// <param name="includes"></param>
        /// <param name="disableTracking"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                       List<Expression<Func<T, object>>> includes = null,
                                       bool disableTracking = true);

        /// <summary>
        /// Get by Id Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Add Async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Update Async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Delete Async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(T entity);
    }
}