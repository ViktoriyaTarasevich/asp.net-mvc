using System;
using DataAccess.Context;
using DataAccess.Repository;
using MovieTickets.Entities.Models;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        MovieTicketContext Context { get; }
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void Save();
    }
}