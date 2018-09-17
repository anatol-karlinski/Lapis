using Lapis.DAL.Interfaces.Patterns;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lapis.DAL.Abstracts.Patterns
{
    public class RepositoryAbstract<T> : IRepository<T>
        where T : class
    {
        protected readonly DataContext _context;

        public RepositoryAbstract(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>()
                .ToList()
                .AsEnumerable();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return (await _context.Set<T>()
                .ToListAsync())
                .AsEnumerable();
        }

        public T GetFirst(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>()
                .Where(exp)
                .FirstOrDefault();
        }

        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> exp)
        {
            return await _context.Set<T>()
                .Where(exp)
                .FirstOrDefaultAsync();
        }

        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>()
                .Where(exp)
                .ToList()
                .AsEnumerable();
        }

        public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> exp)
        {
            return (await _context.Set<T>()
                .Where(exp)
                .ToListAsync())
                .AsEnumerable();
        }

        public T Add(T entity)
        {
            var entityTracking = _context.Add(entity);
            _context.SaveChanges();
            return entityTracking.Entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            var entityTracking = _context.Add(entity);
            await _context.SaveChangesAsync();
            return entityTracking.Entity;
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public T Update(T entity)
        {
            var entityTracking = _context.Update(entity);
            return entityTracking.Entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entityTracking = _context.Update(entity);
            await _context.SaveChangesAsync();
            return entityTracking.Entity;
        }
    }
}
