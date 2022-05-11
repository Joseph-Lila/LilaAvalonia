using Lila.DAL.Repository.DbContext;
using Lila.DAL.Repository.Interfaces;
using Lila.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lila.DAL.Repository.Repositories;

public class TransportsKindRepository : IRepository<TransportsKind>
{
    private readonly ApplicationContext _dbContext;

    public TransportsKindRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<TransportsKind> GetAll()
    {
        return _dbContext.Set<TransportsKind>()
            .Include(transportsKind => transportsKind.Transports)
            .ToList();
    }

    public TransportsKind GetById(int id)
    {
        return GetAll()
            .FirstOrDefault(kind => kind.Id == id)!;
    }

    public int Create(TransportsKind item)
    {
        _dbContext.TransportsKinds.Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void Update(TransportsKind item)
    {
        _dbContext.TransportsKinds.Update(item);
        _dbContext.SaveChanges();
    }

    public void Delete(TransportsKind item)
    {
        _dbContext.TransportsKinds.Remove(item);
        _dbContext.SaveChanges();
    }
}