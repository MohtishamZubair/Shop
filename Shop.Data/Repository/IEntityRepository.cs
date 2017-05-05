using System.Collections.Generic;
using Shop.Models;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace Shop.Repository
{
    public interface IEntityRepository<T> where T:class
    {
        T Save(T entity);
        T Add(T t);
        int CommitChangesTo();


        /// <summary>
        /// Finds object with primary key.
        /// </summary>
        /// <param name="keyValues">primary keys</param>
        /// <returns>Object</returns>
        T Find(params object[] keyValues);
        /// <summary>
        /// Delete the give entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
        /// <summary>
        /// Delete with expression
        /// </summary>
        /// <param name="where"></param>
        void Delete(Expression<Func<T, bool>> where);
        /// <summary>
        /// Delete by Id
        /// </summary>
        /// <param name="id"></param>
        void Delete(object id);
        /// <summary>
        /// Get by expression
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> where);
        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll(int pageNumber=1, int pageSize=10);

        /// <summary>
        /// Get more than one with expression
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        List<T> GetMany(Expression<Func<T, bool>> where);
        /// <summary>
        /// To get entity with childs and sort filter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        List<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

    }
}