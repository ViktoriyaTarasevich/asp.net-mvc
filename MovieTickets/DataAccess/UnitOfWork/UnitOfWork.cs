using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.Repository;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly Dictionary<Type, object> _repositories;
        private bool _disposed;

        public UnitOfWork(DbContext context)
        {
            this._context = context;
            this._repositories = new Dictionary<Type, object>();
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            this._context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }

                this._disposed = true;
            }
        }
    }
}
