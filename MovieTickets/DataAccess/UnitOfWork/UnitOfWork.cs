using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Repository;
using MovieTickets.Entities.Models;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private MovieTicketContext _context;
        private bool _disposed;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork()
        {
            _context = new MovieTicketContext();
            _repositories = new Dictionary<Type, object>();
        }

        public MovieTicketContext Context
        {
            get { return _context; }
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof (TEntity)))
            {
                return _repositories[typeof (TEntity)] as IRepository<TEntity>;
            }
            var repository = new Repository<TEntity>(_context);
            _repositories.Add(typeof (TEntity), repository);
            return repository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_context != null)
                        _context.Dispose();
                    _context = null;
                    _repositories = null;
                }

                _disposed = true;
            }
        }
    }
}