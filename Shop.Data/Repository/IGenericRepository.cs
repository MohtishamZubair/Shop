using Shop.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Shop.Data.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T Add(T t);
        void Delete(T t);
        T Get(Expression<Func<T, bool>> criteria);

        T Update(T t);

        IEnumerable<T> GetAll();
    }
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbSet<T> dbSet;
        private ApplicationDbContext _dbHandler;
        public IDbSet<T> DbSet { get; set; }

        public GenericRepository(ApplicationDbContext _dbHandler)
        {
            this._dbHandler = _dbHandler;
            this.dbSet = _dbHandler.Set<T>();
        }

        T IGenericRepository<T>.Add(T t)
        {

            T newT = dbSet.Add(t);
            return newT;
        }

        void IGenericRepository<T>.Delete(T t)
        {
            throw new NotImplementedException();
        }

        T IGenericRepository<T>.Get(Expression<Func<T, bool>> criteria)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IGenericRepository<T>.GetAll()
        {
            throw new NotImplementedException();
        }

        T IGenericRepository<T>.Update(T t)
        {
            throw new NotImplementedException();
        }
    }

}