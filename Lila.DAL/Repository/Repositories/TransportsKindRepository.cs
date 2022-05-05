using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class TransportsKindRepository : IRepository<TransportsKind>
{
    private readonly Microsoft.EntityFrameworkCore.DbContext _dbContext;

    public TransportsKindRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<TransportsKind> GetAll()
    {
        return _dbContext.Set<TransportsKind>()
            .Include(transportsKind => transportsKind.Transports)
            .AsNoTracking()
            .ToList();
    }

    public TransportsKind GetById(int id)
    {
        return _dbContext.Set<TransportsKind>()
            .Include(transportsKind => transportsKind.Transports)
            .AsNoTracking()
            .ToList()
            .FirstOrDefault(kind => kind.Id == id)!;
    }

    public int Create(TransportsKind item)
    {
        _dbContext.Set<TransportsKind>().Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(TransportsKind item)
    {
        _dbContext.Set<TransportsKind>().Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(TransportsKind item)
    {
        _dbContext.Set<TransportsKind>().Remove(item);
        _dbContext.SaveChanges();
    }
}