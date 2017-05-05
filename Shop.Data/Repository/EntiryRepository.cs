using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Shop.Models;
using System.Data.Entity;
using System.Linq;

namespace Shop.Repository
{
    public class EntityRepository<T> : IEntityRepository<T> where T:class
    {
        private IContextRepository context;
        private IDbSet<T> dbSet;

        public EntityRepository(IContextRepository context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }        

        T IEntityRepository<T>.Add(T t)
        {
            T newT = dbSet.Add(t);
            CommitChangesTo();
            return newT;
        }        

        public int CommitChangesTo()
        {
            return context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }

        IEnumerable<T> IEntityRepository<T>.GetAll(int pageNumber = 1, int pageSize = 10)
        {
            return dbSet;
        }

        T IEntityRepository<T>.Save(T entityToUpdate)
        {
            var returnobj = dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            this.CommitChangesTo();            
            return returnobj;
        }        

        public T Find(params object[] keyValues)
        {
            return dbSet.Find(keyValues);
        }

        public void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                //dbContext.Entry(entityToDelete).State = EntityState.Deleted;
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            this.CommitChangesTo();
        }

        void IEntityRepository<T>.Delete(Expression<Func<T, bool>> where)
        {
            var entityTodelete = GetMany(where);
            entityTodelete.ForEach(ed => Delete(ed));
        }

        void IEntityRepository<T>.Delete(object id)
        {
            T entityTodelete = Find(id);
            Delete(entityTodelete);
        }

        public List<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList<T>();
        }

        List<T> IEntityRepository<T>.Get(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
    }
}