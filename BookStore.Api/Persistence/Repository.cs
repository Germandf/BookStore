using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Persistence;

public interface IRepository<T>
{
    void Add(T entity);
    Task<List<T>> GetAll(CancellationToken ct = default);
    Task<T?> GetById(Guid entityId, CancellationToken ct = default);
    void Remove(T entity);
    void Update(T entity);
}

public class Repository<T>(BookStoreDbContext dbContext) : IRepository<T> where T : class
{
    public void Add(T entity) => dbContext.Set<T>().Add(entity);
    public Task<List<T>> GetAll(CancellationToken ct = default) => dbContext.Set<T>().ToListAsync(ct);
    public Task<T?> GetById(Guid entityId, CancellationToken ct = default) => dbContext.Set<T>().FindAsync(entityId, ct).AsTask();
    public void Remove(T entity) => dbContext.Set<T>().Remove(entity);
    public void Update(T entity) => dbContext.Set<T>().Update(entity);
}
