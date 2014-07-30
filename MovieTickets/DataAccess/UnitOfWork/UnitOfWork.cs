using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.Repository;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork<TContext>: IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        private TContext _context;
        private Dictionary<Type, object> _repositories;
        private bool _disposed;

        public TContext Context { get { return _context; } }

        public UnitOfWork()
        {
            this._context = new TContext();
            this._repositories = new Dictionary<Type, object>();
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (this._repositories.Keys.Contains(typeof (TEntity)))
            {
                return this._repositories[typeof (TEntity)] as IRepository<TEntity>;
            }
            var repository = new Repository<TEntity>(this._context);
            this._repositories.Add(typeof(TEntity), repository);
            return repository;
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
                    if(this._context != null)
                        this._context.Dispose();
                    this._context = null;
                    this._repositories = null;
                }

                this._disposed = true;
            }
        }
    }
}
