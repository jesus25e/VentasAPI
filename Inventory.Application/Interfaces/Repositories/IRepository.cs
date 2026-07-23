using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T:BaseEntity
    {
        Task<T?> GetByIdAsyncs(int id);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
