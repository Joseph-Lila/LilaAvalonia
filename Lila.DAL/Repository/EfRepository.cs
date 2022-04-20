using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository;

internal class EfRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly Microsoft.EntityFrameworkCore.DbContext _dbContext;

    public EfRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int> Create(T item)
    {
        _dbContext.Set<T>().Add(item);
        await _dbContext.SaveChangesAsync();

        return item.Id;
    }

    public async Task Delete(int id)
    {
        var entity = await GetById(id);
        if (entity != null) _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public IQueryable<T> GetAll()
    {
        return _dbContext.Set<T>().AsNoTracking();
    }

    public async Task<T?> GetById(int id)
    {
        return await _dbContext.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id);
    }

    public async Task Update(T item)
    {
        _dbContext.Set<T>().Update(item);
        await _dbContext.SaveChangesAsync();
    }
}