using Microsoft.EntityFrameworkCore;
using SchoolSystem.Core.Contract;
using SchoolSystem.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SchoolSystem.Core.Implementation
{
#pragma warning  disable
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly SchoolDbContext _context;
        private readonly DbSet<T> _dbSet;

        private readonly ILogger<BaseRepository<T>> _logger;

        public BaseRepository(SchoolDbContext context, ILogger<BaseRepository<T>> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet=_context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all entities of type {EntityType}.",
                    typeof(T).Name);
                throw;
            }
        }

        public async Task<T> FindById(int id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while finding entity of type {EntityType} by id: {EntityId}.",
                    typeof(T).Name, id);
                throw;
            }
        }

        public async Task<T> FindByName(string name)
        {
            try
            {
                return await _context.Set<T>().FindAsync(name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while finding entity of type {EntityType} by name: {EntityName}.",
                    typeof(T).Name, name);
                throw;
            }
        }

        public  bool IsExist(int id)
        {
            try
            {
                var result =  _context.Set<T>().Find(id);
                return result is not null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while checking existence of entity with id {EntityId}.", id);
                throw;
            }
        }

        public bool IsExist(T entity)
        {
            try
            {
                var result =  _context.Set<T>().Local.Any(e => e == entity) ||
                                                   _context.Set<T>().Any(e => e == entity);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while checking existence of entity.");
                throw;
            }
        }

        public async Task<T> Delete(int id)
        {
            try
            {
                var entity = await FindById(id);
                if (entity != null)
                {
                    _context.Set<T>().Remove(entity);
                    await _context.SaveChangesAsync();
                }

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting entity of type {EntityType} with id: {EntityId}.",
                    typeof(T).Name, id);
                throw;
            }
        }

        public async Task<int> Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting entity of type {EntityType}.", typeof(T).Name);
                throw;
            }
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating entity of type {EntityType}.", typeof(T).Name);
                throw;
            }
        }

        public async Task<T> Create(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating entity of type {EntityType}.", typeof(T).Name);
                throw;
            }
        }

        public async Task<IEnumerable<T>> CreateRange(IEnumerable<T> entities)
        {
            try
            {
                _context.Set<T>().AddRange(entities);
                await _context.SaveChangesAsync();
                return entities;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating range of entities of type {EntityType}.",
                    typeof(T).Name);
                throw;
            }
        }

        public async Task<IEnumerable<T>> UpdateRange(IEnumerable<T> entities)
        {
            try
            {
                _context.Set<T>().UpdateRange(entities);
                await _context.SaveChangesAsync();
                return entities;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating range of entities of type {EntityType}.",
                    typeof(T).Name);
                throw;
            }
        }

        public async Task<int> DeleteRange(IEnumerable<T> entities)
        {
            try
            {
                _context.Set<T>().RemoveRange(entities);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting range of entities of type {EntityType}.",
                    typeof(T).Name);
                throw;
            }
        }

        public async Task<bool> Exists(int id)
        {
            try
            {
                var result = await _context.Set<T>().FindAsync(id);
                return result is not null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while checking existence of entity with id {EntityId}.", id);
                throw;
            }
        }

        public async Task<int> Count()
        {
            try
            {
                return await _context.Set<T>().CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while counting entities of type {EntityType}.", typeof(T).Name);
                throw;
            }
        }

        public async Task<int> Count(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _context.Set<T>().CountAsync(predicate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while counting entities of type {EntityType} with predicate.",
                    typeof(T).Name);
                throw;
            }
        }

        public async Task<bool> Any()
        {
            try
            {
                return await _context.Set<T>().AnyAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while checking if entities of type {EntityType} exist.",
                    typeof(T).Name);
                throw;
            }
        }

        public async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _context.Set<T>().AnyAsync(predicate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error occurred while checking if entities of type {EntityType} with predicate exist.",
                    typeof(T).Name);
                throw;
            }
        }

        public async Task<T> FirstOrDefault()
        {
            try
            {
                return await _context.Set<T>().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting first or default entity of type {EntityType}.",
                    typeof(T).Name);
                throw;
            }
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _context.Set<T>().FirstOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error occurred while getting first or default entity of type {EntityType} with predicate.",
                    typeof(T).Name);
                throw;
            }
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _context.Set<T>().Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while filtering entities of type {EntityType}.", typeof(T).Name);
                throw;
            }
        }

        public virtual async Task<IEnumerable<T>> GetAll(params string[]? includes)
        {
            var query = _dbSet.AsQueryable(); // Convert DbSet to IQueryable

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item); // Update query with included navigation property
                }
            }

            var data = await query.ToListAsync(); // Execute query and retrieve data
            return data;
        }
    }
}
