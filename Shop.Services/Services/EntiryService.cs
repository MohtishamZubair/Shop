using Shop.Models;
using System.Collections.Generic;
using System;
using Shop.Data.Repository;
using Shop.Repository;
using System.Linq.Expressions;
using System.Linq;

namespace Shop.Services
{
    public interface IEntityService<T> where T : class
    {
        List<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        IEnumerable<T> GetAll(int p=1, int s=10);
        T Add(T t);
        T GetById(int id);
        T save(T t);
    }

    public class EntityService<T> : IEntityService<T> where T:class
    {
        IEntityRepository<T> repository;

        public EntityService(IEntityRepository<T> repository)
        {
            this.repository = repository;
        }

        public T Add(T t)
        {
            return repository.Add(t);
        }

        public List<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            return repository.Get(filter, orderBy, includeProperties);
        }

        public IEnumerable<T> GetAll(int p = 1, int s = 10)
        {
            return repository.GetAll();
        }


        public T GetById(int id)
        {
            return repository.Find(id);
        }

        public T save(T t)
        {
            return repository.Save(t);            
        }

    }
}