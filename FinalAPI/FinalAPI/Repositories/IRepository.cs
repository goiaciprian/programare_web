namespace FinalAPI.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T?> UpdateAsync(T entity);
        Task<T?> DeleteAsync(long id);
        Task<IEnumerable<T>> FindAllAsync(Func<T, bool> predicate);
        Task<T?> FindOneAsync(Func<T, bool> predicate);
    }
}
