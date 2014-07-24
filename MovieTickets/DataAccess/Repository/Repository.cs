using System.Collections.Generic;
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

        public TEntity GetById(int id)
        {
            return this._dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            this._dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            
        }

        public void Delete(TEntity entity)
        {
            this._context.Set<TEntity>().Remove(entity);
        }
    }
}
