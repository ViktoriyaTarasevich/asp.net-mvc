using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            this._context = context;
            this._dbSet = this._context.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return this._dbSet.AsQueryable();
        }

        public TEntity GetById<T>(T id)
        {
            if (id != null)
            {
                return this._dbSet.Find(id);
            }
            throw new NoNullAllowedException("entity");
        }

        public void Insert(TEntity entity)
        {
            if (entity != null)
            {
                this._dbSet.Add(entity);
            }
        }

        public void Update(TEntity entity)
        {
            
        }

        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                this._context.Set<TEntity>().Remove(entity);
            }
        }
    }
}
