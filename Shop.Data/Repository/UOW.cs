using Shop.Data.Context;
using System;

namespace Shop.Data.Repository
{
    public interface IUOW:IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
        void Save();
    }
    public class UOW : IUOW
    {
        ApplicationDbContext _dbHandler = ApplicationDbContext.Create();
        IGenericRepository<T> IUOW.GetRepository<T>()
        {
            return new GenericRepository<T>(_dbHandler);
        }

        void IUOW.Save()
        {
            _dbHandler.SaveChanges();
        }

        public void Dispose()
        {
            if (_dbHandler != null)
            {
                _dbHandler.Dispose();
                _dbHandler = null;
            }
        }
    }
}