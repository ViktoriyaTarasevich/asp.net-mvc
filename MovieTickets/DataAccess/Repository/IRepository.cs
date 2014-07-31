using System.Collections.Generic;
using MovieTickets.Entities.Models;

namespace DataAccess.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById<T>(T id);
        void Insert(TEntity entity);
        void Update(int oldEntityId, TEntity entity);
        void Delete(TEntity entity);
    }
}