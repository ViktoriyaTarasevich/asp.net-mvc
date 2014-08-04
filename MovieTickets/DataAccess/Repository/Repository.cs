using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using MovieTickets.Entities.Models;

namespace DataAccess.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public TEntity GetById<T>(T id)
        {
            if (id != null)
            {
                return _dbSet.Find(id);
            }
            throw new NoNullAllowedException("entity");
        }

        public void Insert(TEntity entity)
        {
            if (entity != null)
            {
                _dbSet.Add(entity);
            }
        }

        public void Update(int oldEntityId, TEntity entity)
        {
            if (entity != null)
            {
                var original = _dbSet.Find(oldEntityId);
                if (original != null)
                {
                    _context.Entry(original).CurrentValues.SetValues(entity);
                }
            }
        }

        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
            }
        }
    }
}