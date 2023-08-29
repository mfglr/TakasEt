using Application.Entities;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
	public class Repository<T> : IRepository<T> where T : IEntity
	{
		private readonly SqlContext _context;
		protected readonly DbSet<T> _dbSet;

		public Repository(SqlContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}


		public Task AddAsync(T entity)
		{
			
		}

		public Task GetByIdAsync(Guid Id)
		{
			throw new NotImplementedException();
		}

		public void Remove(T entity)
		{
			throw new NotImplementedException();
		}

		public void RemoveByIdAsync(Guid Id)
		{
			throw new NotImplementedException();
		}

		public void Update(T entity)
		{
			throw new NotImplementedException();
		}
	}
}
