using Lila.DAL.Repository.Interfaces;
using Lila.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository;

internal class EfRepository<TEntity> : IRepository<TEntity>
    where TEntity : class, IBaseEntity
{
    private readonly Microsoft.EntityFrameworkCore.DbContext _dbContext;

    public EfRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>().AsNoTracking().ToList();
    }

    public TEntity GetById(int id)
    {
        return _dbContext.Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefault(e => e.Id == id)!;
    }

    public void Create(TEntity item)
    {
        _dbContext.Set<TEntity>().Add(item);
        _dbContext.SaveChanges();
    }

    public void Update(TEntity item)
    {
        _dbContext.Set<TEntity>().Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(TEntity item)
    {
        _dbContext.Set<TEntity>().Remove(item);
        _dbContext.SaveChanges();
    }
}