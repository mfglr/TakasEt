using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task AddAsync(T entity);
        Task GetByIdAsync(Guid Id);
        void Update(T entity);
        void Remove(T entity);
        void RemoveByIdAsync(Guid Id);
    }
}
