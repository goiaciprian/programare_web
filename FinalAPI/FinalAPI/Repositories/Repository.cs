using FinalAPI.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace FinalAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Database _database;
        private readonly ILogger<Repository<T>> _logger;

        public Repository(Database database, ILogger<Repository<T>> logger)
        {
            _database = database;
            _logger = logger;
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                _database.Entry<T>(entity).State = EntityState.Added;
                await _database.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError("{e.Message}", e.Message);
            }
            return null;
        }

        public async Task<T?> DeleteAsync(long id)
        {
            try
            {
                var toDelete = await _database.FindAsync<T>(id);
                if (toDelete != null)
                {
                    _database.Entry<T>(toDelete).State = EntityState.Deleted;
                    await _database.SaveChangesAsync();
                    return toDelete;
                }
                return null;
            }
            catch (Exception e)
            {
                _logger.LogError("{e.Message}", e.Message);
                return null;
            }
        }

        public async Task<T?> UpdateAsync(T entity)
        {
            try
            {
                _database.Entry<T>(entity).State = EntityState.Modified;
                await _database.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError("{e.Message}", e.Message);
            }
            return null;
        }


        public async Task<IEnumerable<T>> FindAllAsync(Func<T, bool> predicate)
        {
            return await Task.Run(() => _database.Set<T>().Where(predicate).ToList());
        }

        public async Task<T?> FindOneAsync(Func<T, bool> predicate)
        {
            return await Task.Run(() =>
            {
                try
                {
                    return _database.Set<T>().Where(predicate).First();
                }
                catch (Exception e)
                {
                    _logger.LogError("{e.Message}", e.Message);
                    return null;
                }
            });
        }

    }
}
